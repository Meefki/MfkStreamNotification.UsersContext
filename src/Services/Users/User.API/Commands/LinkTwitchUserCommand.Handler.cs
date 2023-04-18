namespace Users.API.Commands;

public class LinkTwitchUserCommandHandler
    : IRequestHandler<LinkTwitchUserCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public LinkTwitchUserCommandHandler(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(LinkTwitchUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(new(Guid.Parse(request.UserId)));

        if (user is null)
            return false;

        TwitchUser twitchUser = new(
            new(request.TwitchUser.Id),
            request.TwitchUser.Login,
            request.TwitchUser.Email,
            scopeString: request.TwitchUser.Scopes);
        user.LinkTwitchUser(twitchUser);

        return await _userRepository.UnitOfWork
            .SaveEntitiesAsync();
    }
}
