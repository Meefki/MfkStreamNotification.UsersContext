namespace Users.API.Queries;

public record User
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string DisplayName { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public List<Connection> Connections { get; set; } = new();
}

public record Connection
{
    public Guid Id { get; set; }
    public string ConnectionTo { get; set; }
    public string ForeignUserId { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string Scopes { get; set; }
}
