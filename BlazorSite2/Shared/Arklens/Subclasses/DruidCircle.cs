namespace BlazorSite2.Shared.Arklens.Subclasses;

public class DruidCircle : Subclass
{
	public DruidCircle(string emoji, string name) : base(emoji, name)
	{
	}

	public static readonly DruidCircle Floralyth = new("🌿", "Флорилит");
	public static readonly DruidCircle Zoolyth = new("🦌", "Зоолит");
	public static readonly DruidCircle Ethnolyth = new("🦂", "Этнолит");
	public static readonly DruidCircle Decalyth = new("🍖", "Декалит");
	public static readonly DruidCircle Micolyth = new("🍄", "Миколит");
	
	public static readonly IReadOnlyList<DruidCircle> All = new[] 
	{ Floralyth, Zoolyth, Ethnolyth, Decalyth, Micolyth };
}
