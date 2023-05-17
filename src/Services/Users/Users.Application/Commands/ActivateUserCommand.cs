namespace Users.Application.Commands;

public class ActivateUserCommand
    : IRequest<bool>
{
    public string UserId { get; set; }

    public ActivateUserCommand(string userId)
    {
        UserId = userId;
    }
}
