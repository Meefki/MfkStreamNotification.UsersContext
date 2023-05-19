using Subscriptions.Domain.SeedWork;

namespace Subscriptions.Domain.Aggregates;

public class Provider
    : Enumeration
{
    public static Provider Common = new(1, nameof(Common));
    public static Provider Twitch = new(2, nameof(Twitch));
    public static Provider YouTube = new(3, nameof(YouTube));
    public static Provider Trovo = new(4, nameof(Trovo));

    public Provider(int id, string name) 
        : base(id, name)
    {
    }
}