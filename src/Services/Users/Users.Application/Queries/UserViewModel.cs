namespace Users.Application.Queries;

public record User
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string DisplayName { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string? Email { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public List<Connection> Connections { get; set; } = new();
}

public record Connection
{
    public Guid Id { get; set; }
    public string ConnectionTo { get; set; } = string.Empty;
    public string ForeignUserId { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string Scopes { get; set; } = string.Empty;
}
