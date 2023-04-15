using Users.Application.DomainEventHandlers.UserCreatedDomainEventHandler;
using Users.Application.SeedWork.Mediator;
using Users.Domain.SeedWork.Mediator;

namespace Users.API.AutofacModules;

public class DomainEventMediatorModule
    : Autofac.Module
{
    public static IServiceScopeFactory? ServiceScopeFactory { get; set; }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DomainEventMediator>()
            .As<IDomainEventMediator>()
            .SingleInstance();
    }
}
