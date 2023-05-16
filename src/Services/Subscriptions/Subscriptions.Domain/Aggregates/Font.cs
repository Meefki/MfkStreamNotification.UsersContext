using Subscriptions.Domain.DomainExceptions;
using Subscriptions.Domain.SeedWork;

namespace Subscriptions.Domain.Aggregates;

public enum FontLining
{
    None,
    Strikethrough,
    Underline
}

public class Font
    : ValueObject
{
    public string Name { get; init; }
    public float Size { get; init; }
    public bool IsBold { get; init; }
    public bool IsItalic { get; init; }
    public FontLining FontLining { get; init; }

    public Font(
        string name,
        float size,
        bool isBold,
        bool isItalic,
        FontLining fontLining)
    {
        if (size < 0)
            throw new InvalidFontSizeException(size);

        Name = name;
        Size = size;
        IsBold = isBold;
        IsItalic = isItalic;
        FontLining = fontLining;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Size;
        yield return IsBold;
        yield return IsItalic;
        yield return FontLining;
    }

    public static bool operator ==(Font left, Font right)
        => EqualOperator(left, right);

    public static bool operator !=(Font left, Font right)
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