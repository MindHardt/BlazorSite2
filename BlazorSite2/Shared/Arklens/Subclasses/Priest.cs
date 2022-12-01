namespace BlazorSite2.Shared.Arklens.Subclasses;

public class PriestFaith : Subclass
{
	public Alignment GodAlignment { get; }
	public PriestFaith(string emoji, string name, Alignment godAlignment) : base(emoji, name)
	{
		GodAlignment= godAlignment;
	}

	public static PriestFaith Nerasith { get; } = new("⚒️", "Нерасит", Alignment.LawfulGood);
	public static PriestFaith Solarith { get; } = new("🌞", "Солярит", Alignment.NeutralGood);
	public static PriestFaith Yunaith { get; } = new("🌟", "Юнаит", Alignment.LawfulGood);

	public static PriestFaith Avarith { get; } = new("⚔️", "Аварит", Alignment.LawfulNeutral);
	public static PriestFaith Jastarith { get; } = new("⚖️", "Джастарит", Alignment.Neutral);
	public static PriestFaith Morthith { get; } = new("💋", "Мортит", Alignment.ChaoticNeutral);

	public static PriestFaith Archivarith { get; } = new("💀", "Архиварит", Alignment.LawfulEvil);
	public static PriestFaith Asterith { get; } = new("👑", "Астерит", Alignment.NeutralEvil);
	public static PriestFaith Sangith { get; } = new("🦷", "Сангит", Alignment.ChaoticEvil);

	public static IReadOnlyList<PriestFaith> All { get; } = new[] { Nerasith, Solarith, Yunaith, Avarith, Jastarith, Morthith, Archivarith, Asterith, Sangith };
}
