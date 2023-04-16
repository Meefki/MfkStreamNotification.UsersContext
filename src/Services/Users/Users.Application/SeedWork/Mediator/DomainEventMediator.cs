using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;
using System.Reflection;

namespace Users.Application.SeedWork.Mediator;

public sealed class DomainEventMediator : IDomainEventMediator
{
    private readonly ConcurrentDictionary<Type, List<object>> _handlers = new();

    private readonly IServiceScopeFactory _serviceProviderFactory;
    private bool _isInitialized = false;

    public DomainEventMediator(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceProviderFactory = serviceScopeFactory;
    }

    public async Task Publish<T>(T domainEvent, CancellationToken cancellationToken = default)
        where T : IDomainEvent
    {
        var domainEventType = domainEvent.GetType();
        if (_handlers.ContainsKey(domainEventType))
            foreach (var handler in _handlers[domainEventType])
            {
                var handlerType = handler.GetType();
                var domainHandler = Convert.ChangeType(handler, handlerType);

                var handleMethod = handler
                    .GetType()
                    .GetMethod(nameof(IDomainEventHandler<IDomainEvent>.Handle));

                var asyncMethod = (Task)handleMethod!.Invoke(handler, new object[] { domainEvent, cancellationToken })!;

                await asyncMethod;
            }
    }

    public void Register<T>(IDomainEventHandler<T> handler)
        where T : IDomainEvent
    {
        var domainEventType = typeof(T);
        if (!_handlers.ContainsKey(domainEventType))
            _handlers[domainEventType] = new();

        _handlers[domainEventType].Add(handler);
    }

    public void Initialize()
    {
        if (_isInitialized)
            throw new InvalidOperationException($"{typeof(DomainEventMediator).FullName} was already initialized");

        _isInitialized = true;

        var domainEventHandlerTypes = Assembly
                .GetAssembly(typeof(DomainEventMediator))!
                .GetTypes()
                .Where(x => x.GetInterfaces()
                    .Any(y => y.IsGenericType
                           && y.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>)));

        using var scope = _serviceProviderFactory.CreateScope();
        foreach (var handlerType in domainEventHandlerTypes)
        {
            var domainEventType = handlerType
                .GetInterfaces()
                .First()
                .GetGenericArguments()
                .First();
            var registereMethod = typeof(DomainEventMediator)
                .GetMethod(nameof(DomainEventMediator.Register))!
                .MakeGenericMethod(domainEventType!);

            var handlerInstance = ActivatorUtilities.CreateInstance(scope.ServiceProvider, handlerType)!;

            registereMethod.Invoke(this, new object[] { handlerInstance });
        }
    }
}
