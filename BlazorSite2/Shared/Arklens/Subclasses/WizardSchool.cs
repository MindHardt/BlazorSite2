namespace BlazorSite2.Shared.Arklens.Subclasses;

public class WizardSchool : Subclass
{
	public WizardSchool(string emoji, string name) : base(emoji, name)
	{
	}

	public static readonly WizardSchool Universalist = new("🧙‍", "Универсалист");
	public static readonly WizardSchool Animaturg = new("👻", "Аниматург");
	public static readonly WizardSchool Illusionist = new("👁‍", "Иллюзионист");
	public static readonly WizardSchool Disruptor = new("💥", "Дизраптор");
	public static readonly WizardSchool Transmutator = new("🔁", "Трансмутатор");
	public static readonly WizardSchool Relocator = new("💫", "Релокатор");
	public static readonly WizardSchool Seer = new("🔮", "Провидец");

	public static readonly IReadOnlyList<WizardSchool> All = new[]
	{ Universalist, Animaturg, Illusionist, Disruptor, Transmutator, Relocator, Seer };
}
