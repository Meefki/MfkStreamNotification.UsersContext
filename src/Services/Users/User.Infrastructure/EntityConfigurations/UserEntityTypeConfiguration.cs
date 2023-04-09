using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Users.Infrastructure.EntityConfigurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users", UsersContext.DEFAULT_SCHEMA);

        builder.Ignore(u => u.DomainEvents);

        builder
            .Property(u => u.Id)
            .HasConversion(
                userId => userId.Value,
                value => new UserId(value))
            .UseHiLo("userseq", UsersContext.DEFAULT_SCHEMA);
        builder.HasKey(u => u.Id);

        builder
            .HasOne(u => u.TwitchUser)
            .WithOne()
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .OwnsOne(u => u.Credentials);

        builder
            .Property(u => u.CreatedDate)
            .HasField("_createdDate")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();
    }
}
