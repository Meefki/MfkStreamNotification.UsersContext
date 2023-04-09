using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Users.Infrastructure.EntityConfigurations;

public class TwitchUserEntityTypeConfiguration : IEntityTypeConfiguration<TwitchUser>
{
    public void Configure(EntityTypeBuilder<TwitchUser> builder)
    {
        builder.ToTable("twitch_users", UsersContext.DEFAULT_SCHEMA);

        builder.Ignore(tu => tu.DomainEvents);

        builder
            .Property(tu => tu.Id)
            .HasField("_id")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .UseHiLo("twitchuserseq", UsersContext.DEFAULT_SCHEMA);
        builder.HasKey(tu => tu.Id);

        builder
            .Property(tu => tu.Scopes)
            .HasField("_scopes")
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
