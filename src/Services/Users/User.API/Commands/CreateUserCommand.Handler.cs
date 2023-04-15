namespace Users.API.Commands;

public class CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        Credentials credentials = new(
            request.DisplayName,
            request.Login,
            request.Email,
            request.Password);
        User user = new(credentials);

        _userRepository.Add(user);

        return await _userRepository.UnitOfWork
            .SaveEntitiesAsync(cancellationToken);
    }
}
