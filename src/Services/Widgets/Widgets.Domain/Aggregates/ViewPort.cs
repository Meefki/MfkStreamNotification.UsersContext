using Subscriptions.Domain.Aggregates.Abstractions;
using Subscriptions.Domain.DomainExceptions;

namespace Subscriptions.Domain.Aggregates;

public class ViewPort
    : ComponentVO
{
    public Picture? Picture { get; init; }
    public Audio? Audio { get; init; }

    private readonly List<Text> _texts;
    public IReadOnlyCollection<Text> Texts
        => _texts.AsReadOnly();

    public ViewPort(
        Position position,
        Size size,
        Duration duration,
        Picture? picture = null,
        Audio? audio = null,
        ICollection<Text>? texts = null)
        : base(position, size, duration)
    {
        if (picture is null &&
            audio is null &&
            (texts is null ||
            texts.Count == 0))
        {
            throw new AttemptToCreateEmptyViewPortException();
        }

        Picture = picture;
        Audio = audio;

        _texts = new();
        if (texts is not null)
            foreach (Text text in texts)
            {
                _texts.Add(text.ChangeDuration(duration));
            }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return base.GetEqualityComponents();

        yield return Picture ?? Picture.CreateEmpty();
        yield return Audio ?? Audio.CreateEmpty();
        yield return Texts;
    }

    public static bool operator ==(ViewPort left, ViewPort right)
        => EqualOperator(left, right);

    public static bool operator !=(ViewPort left, ViewPort right)
        => NotEqualOperator(left, right);

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}