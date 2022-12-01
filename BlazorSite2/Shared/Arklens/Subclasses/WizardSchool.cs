namespace BlazorSite2.Shared.Arklens.Subclasses;

public class WizardSchool : Subclass
{
	public WizardSchool(string emoji, string name) : base(emoji, name)
	{
	}

	public static WizardSchool Universalist { get; } = new("🧙‍", "Универсалист");
	public static WizardSchool Animaturg { get; } = new("👻", "Аниматург");
	public static WizardSchool Illusionist { get; } = new("👁‍", "Иллюзионист");
	public static WizardSchool Disruptor { get; } = new("💥", "Дизраптор");
	public static WizardSchool Transmutator { get; } = new("🔁", "Трансмутатор");
	public static WizardSchool Relocator { get; } = new("💫", "Релокатор");
	public static WizardSchool Seer { get; } = new("🔮", "Провидец");

	public static IReadOnlyList<WizardSchool> All { get; } = new[] { Universalist, Animaturg, Illusionist, Disruptor, Transmutator, Relocator, Seer };
}
