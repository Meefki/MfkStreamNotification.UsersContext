namespace Users.Application.Commands;

public class RemoveConnectionCommand
    : IRequest<bool>
{
    public string UserId { get; set; }
    public string ConnectionTo { get; set; }

    public RemoveConnectionCommand(string userId, string connectionTo)
    {
        UserId = userId;
        ConnectionTo = connectionTo;
    }
}
