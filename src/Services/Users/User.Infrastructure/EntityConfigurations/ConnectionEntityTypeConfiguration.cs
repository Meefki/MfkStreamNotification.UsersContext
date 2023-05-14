using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Users.Infrastructure.EntityConfigurations;

public class ConnectionEntityTypeConfiguration : IEntityTypeConfiguration<Connection>
{
    public void Configure(EntityTypeBuilder<Connection> builder)
    {
        builder.ToTable("connections", UsersContext.DEFAULT_SCHEMA);

        builder.Ignore(tu => tu.DomainEvents);
        builder.Ignore(tu => tu.Scopes);
        builder.Ignore(tu => tu.AreScopesProvided);

        builder
            .Property(tu => tu.Id)
            .HasConversion(
                connectionId => connectionId.Value,
                value => new ConnectionId(value));
        builder.HasKey(tu => tu.Id);

        builder
            .Property("_scopes")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Scopes");

        builder.Property(c => c.UserId);
        builder.Property(c => c.ConnectionTo);
    }
}
