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
            .HasField("_id")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .UseHiLo("userseq", UsersContext.DEFAULT_SCHEMA);
        builder.HasKey(u => u.Id);

        builder
            .Navigation(u => u.TwitchUser);

        builder
            .Property(u => u.CreatedDate)
            .HasField("_createdDate")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();
    }
}
