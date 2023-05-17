namespace Users.Application.Commands;

public class RestoreUserCommandHandler
    : IRequestHandler<RestoreUserCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public RestoreUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(RestoreUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(new(Guid.Parse(request.UserId)));

        if (user is null)
            return false;

        user.RestoreUser();

        return await _userRepository.UnitOfWork
            .SaveEntitiesAsync();
    }
}
