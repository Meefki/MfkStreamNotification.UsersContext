namespace Users.API.Commands;

public class UnlinkTwitchUserCommandHandler
    : IRequestHandler<UnlinkTwitchUserCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public UnlinkTwitchUserCommandHandler(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(UnlinkTwitchUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(new(Guid.Parse(request.UserId)));

        if (user is null)
            return false;

        user.UnlinkTwitchUser();

        return await _userRepository.UnitOfWork
            .SaveEntitiesAsync();
    }
}
