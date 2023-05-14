using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Users.Infrastructure.EntityConfigurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users", UsersContext.DEFAULT_SCHEMA);

        builder.Ignore(u => u.DomainEvents);

        builder.HasKey(u => u.Id);

        builder
            .Property(u => u.Id)
            .HasConversion(
                userId => userId.Value,
                value => UserId.Create(value));

        builder.Navigation(u => u.Connections)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.OwnsMany(u => u.Connections, options =>
        {
            options.ToTable("connections", UsersContext.DEFAULT_SCHEMA);

            options.WithOwner().HasForeignKey("UserId");

            options.Ignore(tu => tu.DomainEvents);
            options.Ignore(tu => tu.Scopes);
            options.Ignore(tu => tu.AreScopesProvided);

            options
                .Property(tu => tu.Id)
                .HasConversion(
                    connectionId => connectionId.Value,
                    value => ConnectionId.Create(value));
            options.HasKey(tu => tu.Id);

            options
                .Property("_scopes")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Scopes");

            options
                .Property(c => c.ForeignUserId);

            options
                .Property(c => c.ConnectionTo)
                .HasConversion(
                    input => input.Name,
                    output => Enumeration.FromDisplayName<ConnectionTo>(output));
        });

        builder.OwnsOne(u => u.Credentials, 
            options =>
            {
                options
                    .HasIndex(u => u.Email)
                    .IsUnique()
                    .HasDatabaseName("Unique_Email");

                options
                    .HasIndex(u => u.Login)
                    .IsUnique()
                    .HasDatabaseName("Unique_Login");
            }
        );

        builder
            .Property(u => u.CreatedDate)
            .HasField("_createdDate")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();
    }
}
