namespace Users.Application.Commands;

public class CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        Credentials credentials = new(
            request.DisplayName,
            request.Login,
            request.Email,
            request.Password);
        User user = new(credentials);

        _userRepository.Add(user);

        await _userRepository.UnitOfWork
            .SaveEntitiesAsync(cancellationToken);

        return user.Id.Value;
    }
}
