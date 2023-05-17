namespace Users.Application.Commands;

public class RemoveConnectionCommand
    : IRequest<bool>
{
    public string UserId { get; set; }
    public ConnectionTo ConnectionTo { get; set; }

    public RemoveConnectionCommand(string userId, ConnectionTo connectionTo)
    {
        UserId = userId;
        ConnectionTo = connectionTo;
    }
}
