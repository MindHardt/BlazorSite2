namespace BlazorSite2.Shared.Arklens.Subclasses;

public class DruidCircle : Subclass
{
	public DruidCircle(string emoji, string name) : base(emoji, name)
	{
	}

	public static DruidCircle Floralyth { get; } = new("🌿", "Флорилит");
	public static DruidCircle Zoolyth { get; } = new("🦌", "Зоолит");
	public static DruidCircle Ethnolyth { get; } = new("🦂", "Этнолит");
	public static DruidCircle Decalyth { get; } = new("🍖", "Декалит");
	public static DruidCircle Micolyth { get; } = new("🍄", "Миколит");
	
	public static IReadOnlyList<DruidCircle> All { get; } = new[] { Floralyth, Zoolyth, Ethnolyth, Decalyth, Micolyth };
}
