using Subscriptions.Domain.SeedWork;

namespace Subscriptions.Domain.Aggregates;

public class RenderType
    : Enumeration
{
    public static RenderType NoTransform => new(1, nameof(NoTransform));
    public static RenderType Stretching => new(2, nameof(Stretching));
    public static RenderType Repeating => new(3, nameof(Repeating));

    public RenderType(int id, string name) : base(id, name)
    {
    }
}