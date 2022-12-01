namespace BlazorSite2.Shared.Arklens.Subclasses;

public class PriestFaith : Subclass
{
	public PriestFaith(string emoji, string name, Alignment godAlignment) : base(emoji, name)
	{
		GodAlignment= godAlignment;
	}

	public Alignment GodAlignment { get; }

	public static readonly PriestFaith Nerasith = new("⚒️", "Нерасит", Alignment.LawfulGood);
	public static readonly PriestFaith Solarith = new("🌞", "Солярит", Alignment.NeutralGood);
	public static readonly PriestFaith Yunaith = new("🌟", "Юнаит", Alignment.LawfulGood);

	public static readonly PriestFaith Avarith = new("⚔️", "Аварит", Alignment.LawfulNeutral);
	public static readonly PriestFaith Jastarith = new("⚖️", "Джастарит", Alignment.Neutral);
	public static readonly PriestFaith Morthith = new("💋", "Мортит", Alignment.ChaoticNeutral);

	public static readonly PriestFaith Archivarith = new("💀", "Архиварит", Alignment.LawfulEvil);
	public static readonly PriestFaith Asterith = new("👑", "Астерит", Alignment.NeutralEvil);
	public static readonly PriestFaith Sangith = new("🦷", "Сангит", Alignment.ChaoticEvil);

	public readonly static IReadOnlyList<PriestFaith> All = new[] 
	{ Nerasith, Solarith, Yunaith, Avarith, Jastarith, Morthith, Archivarith, Asterith, Sangith };
}
