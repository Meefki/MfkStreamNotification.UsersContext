using Users.Application.Repositories;
using Users.Domain.SeedWork;

namespace Users.Application.Commands;

public class AddConnectionCommandHandler
    : IRequestHandler<AddConnectionCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public AddConnectionCommandHandler(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(AddConnectionCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(new(Guid.Parse(request.UserId)));

        if (user is null)
            return false;

        Connection connection = new(
            new(Guid.NewGuid()),
            Enumeration.FromDisplayName<ConnectionTo>(request.Connection.ConnectionTo),
            request.Connection.Id,
            request.Connection.Login,
            request.Connection.Email,
            scopeString: request.Connection.Scopes);
        user.AddConnection(connection);

        return await _userRepository.UnitOfWork
            .SaveEntitiesAsync(cancellationToken);
    }
}
