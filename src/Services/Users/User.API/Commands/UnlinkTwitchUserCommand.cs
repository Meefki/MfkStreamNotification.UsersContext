namespace Users.API.Commands;

public class UnlinkTwitchUserCommand
    : IRequest<bool>
{
    public string UserId { get; set; }

    public UnlinkTwitchUserCommand(string userId)
    {
        UserId = userId;
    }
}
