using Users.Application.Repositories;

namespace Users.Application.Commands;

public class ActivateUserCommandHandler
    : IRequestHandler<ActivateUserCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public ActivateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(ActivateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(new(Guid.Parse(request.UserId)));

        if (user is null)
            return false;

        user.ActivateUser();

        return await _userRepository.UnitOfWork
            .SaveEntitiesAsync();
    }
}
