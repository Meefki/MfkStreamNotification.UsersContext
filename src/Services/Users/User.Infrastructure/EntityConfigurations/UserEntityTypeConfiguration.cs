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
                value => new UserId(value));

        builder.Navigation(u => u.TwitchUser);

        builder
            .OwnsOne(u => u.Credentials);

        builder
            .Property(u => u.CreatedDate)
            .HasField("_createdDate")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();
    }
}
