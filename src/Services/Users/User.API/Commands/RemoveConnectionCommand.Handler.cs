namespace Users.API.Commands;

public class RemoveConnectionCommandHandler
    : IRequestHandler<RemoveConnectionCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public RemoveConnectionCommandHandler(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(RemoveConnectionCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(new(Guid.Parse(request.UserId)));

        if (user is null)
            return false;

        user.RemoveConnection(request.ConnectionTo);

        return await _userRepository.UnitOfWork
            .SaveEntitiesAsync();
    }
}
