using System.Text;

namespace BlazorSite2.Shared.Arklens;
public class Alignment : CharacterElement
{
    public VerticalAlignment Vertical { get; }
    public HorizontalAlignment Horizontal { get; }

    private Alignment(HorizontalAlignment horizontal, VerticalAlignment vertical)
        : base(GetEmoji(horizontal, vertical), GetName(horizontal, vertical))
    {
        Vertical = vertical;
        Horizontal = horizontal;
    }

    /// <summary>
    /// Gets the step distance between two alignments.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int DistanceTo(Alignment other)
    {
        int verticalDistance = Math.Abs((int)Vertical - (int)other.Vertical);
        int horizontalDistance = Math.Abs((int)Horizontal - (int)other.Horizontal);

        return verticalDistance + horizontalDistance;
    }

    private static string GetEmoji(HorizontalAlignment horizontal, VerticalAlignment vertical)
        => new StringBuilder(4)
        .Append('[')
        .Append(horizontal switch
        {
            HorizontalAlignment.Lawful => "L",
            HorizontalAlignment.Neutral => "N",
            HorizontalAlignment.Chaotic => "C",
            _ => throw new ArgumentOutOfRangeException(nameof(horizontal))
        })
        .Append(vertical switch
        {
            VerticalAlignment.Good => "G",
            VerticalAlignment.Neutral => "N",
            VerticalAlignment.Evil => "E",
            _ => throw new ArgumentOutOfRangeException(nameof(vertical)),
        })
        .Append(']')
        .ToString();
    private static string GetName(HorizontalAlignment horizontal, VerticalAlignment vertical) =>
        horizontal == HorizontalAlignment.Neutral && vertical == VerticalAlignment.Neutral ?
        "Нейтральное" :
        new StringBuilder(20)
        .Append(horizontal switch
        {
            HorizontalAlignment.Lawful => "Законно",
            HorizontalAlignment.Neutral => "Нейтрально",
            HorizontalAlignment.Chaotic => "Хаотично",
            _ => throw new ArgumentOutOfRangeException(nameof(horizontal))
        })
        .Append('-')
        .Append(vertical switch
        {
            VerticalAlignment.Good => "доброе",
            VerticalAlignment.Neutral => "нейтральное",
            VerticalAlignment.Evil => "злое",
            _ => throw new ArgumentOutOfRangeException(nameof(vertical)),
        })
        .ToString();

    /// <summary>
    /// Represents a good-evil axis of an alignment.
    /// </summary>
    public enum VerticalAlignment
    {
        Good,
        Neutral,
		Evil,
	}
    /// <summary>
    /// Represents a lawful-chaotic axis of an alignment.
    /// </summary>
    public enum HorizontalAlignment
    {
        Lawful,
        Neutral,
        Chaotic,
    }

    public readonly static Alignment LawfulGood = new(HorizontalAlignment.Lawful, VerticalAlignment.Good);
    public readonly static Alignment NeutralGood = new(HorizontalAlignment.Neutral, VerticalAlignment.Good);
    public readonly static Alignment ChaoticGood = new(HorizontalAlignment.Chaotic, VerticalAlignment.Good);

    public readonly static Alignment LawfulNeutral = new(HorizontalAlignment.Lawful, VerticalAlignment.Neutral);
    public readonly static Alignment Neutral = new(HorizontalAlignment.Neutral, VerticalAlignment.Neutral);
    public readonly static Alignment ChaoticNeutral = new(HorizontalAlignment.Chaotic, VerticalAlignment.Neutral);

    public readonly static Alignment LawfulEvil = new(HorizontalAlignment.Lawful, VerticalAlignment.Evil);
    public readonly static Alignment NeutralEvil = new(HorizontalAlignment.Neutral, VerticalAlignment.Evil);
    public readonly static Alignment ChaoticEvil = new(HorizontalAlignment.Chaotic, VerticalAlignment.Evil);

    public readonly static IReadOnlyList<Alignment> All = new[]
    {
        LawfulGood, NeutralGood, ChaoticGood,
        LawfulNeutral, Neutral, ChaoticNeutral,
        LawfulEvil, NeutralEvil, ChaoticEvil,
    };
}
