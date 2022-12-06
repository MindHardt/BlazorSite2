using BlazorSite2.Shared.Arklens.Stats;

namespace BlazorSite2.Shared.Arklens;
public class Race : CharacterElement
{
    private readonly Func<StatSet, (Stat amp1, Stat amp2, Stat red)?> _statImpact;
    public IReadOnlyList<string> Traits { get; }

    private Race(
        string emoji,
        string name,
        (string, string) traits,
        Func<StatSet, (Stat amp1, Stat amp2, Stat red)?> statImpact)
        : base(emoji, name)
    {
        Traits = new[] { traits.Item1, traits.Item2 };
        _statImpact = statImpact;
    }

	/// <summary>
	/// Gets stats that get amplified for the character and a stat that gets reduced
	/// or <see langword="null"/> if other behaviour is expected.
	/// </summary>
	public (Stat amp1, Stat amp2, Stat red)? GetRaceImpactFor(StatSet stats) => _statImpact(stats);

	public static Race Human { get; } = new("🧑", "Человек", ("Умелец", "Доп. черта"), _ => null);
    public static Race Elf { get; } = new("🧝", "Эльф", ("Инсомния", "Эльфийская чуткость"), s => (s.Dex, s.Int, s.Con));
    public static Race Dwarf { get; } = new("🧔", "Дварф", ("Каменная стойкость", "Неостановимый"), s => (s.Con, s.Wis, s.Cha));
    public static Race Kitsune { get; } = new("🦊", "Кицуне", ("Регенерация", "Когти"), s => (s.Dex, s.Cha, s.Str));
    public static Race Minas { get; } = new("♉", "Минас", ("Второе дыхание", "Рога"), s => (s.Str, s.Con, s.Int));
    public static Race Serpent { get; } = new(" 🦎", "Серпент", ("Гидроадаптация", "Чешуя"), s => (s.Con, s.Int, s.Wis));

    public static IReadOnlyList<Race> All { get; } = new[] { Human, Elf, Dwarf, Kitsune, Minas, Serpent };
}
