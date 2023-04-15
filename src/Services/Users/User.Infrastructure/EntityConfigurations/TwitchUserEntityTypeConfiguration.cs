using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Users.Infrastructure.EntityConfigurations;

public class TwitchUserEntityTypeConfiguration : IEntityTypeConfiguration<TwitchUser>
{
    public void Configure(EntityTypeBuilder<TwitchUser> builder)
    {
        builder.ToTable("twitch_users", UsersContext.DEFAULT_SCHEMA);

        builder.Ignore(tu => tu.DomainEvents);
        builder.Ignore(tu => tu.Scopes);

        builder
            .Property(tu => tu.Id)
            .HasConversion(
                twitchUserId => twitchUserId.Value,
                value => new TwitchUserId(value));
        builder.HasKey(tu => tu.Id);

        builder
            .Property("_scopes")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Scopes");
    }
}
