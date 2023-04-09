namespace Users.Domain.Aggregates.Users;

public record Credentials(string DisplayName, string Login, string Email, string Password);
