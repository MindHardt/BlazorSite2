namespace BlazorSite2.Shared.Arklens;
public class Race : CharacterElement
{
    private readonly Func<Character, (Stat amp1, Stat amp2, Stat red)?> _statImpact;
    public IReadOnlyList<string> Traits { get; }
    private Race(
        string emoji,
        string name,
        (string, string) traits,
        Func<Character, (Stat amp1, Stat amp2, Stat red)?> statImpact)
        : base(emoji, name)
    {
        Traits = new[] { traits.Item1, traits.Item2 };
        _statImpact = statImpact;
    }

	/// <summary>
	/// Gets stats that get amplified for the character and a stat that gets reduced
	/// or <see langword="null"/> if other behaviour is expected.
	/// </summary>
	public (Stat amp1, Stat amp2, Stat red)? GetRaceImpactFor(Character character) => _statImpact(character);
    public (string Male, string Female) GetPortraitFileNames() => ($"{Name}.М.png", $"{Name}.Ж.png");

	public static Race Human { get; } = new("🧑", "Человек", ("Умелец", "Доп. черта"), _ => null);
    public static Race Elf { get; } = new("🧝", "Эльф", ("Инсомния", "Эльфийская чуткость"), c => (c.Dex, c.Int, c.Con));
    public static Race Dwarf { get; } = new("🧔", "Дварф", ("Каменная стойкость", "Неостановимый"), c => (c.Con, c.Wis, c.Cha));
    public static Race Kitsune { get; } = new("🦊", "Кицуне", ("Регенерация", "Когти"), c => (c.Dex, c.Cha, c.Str));
    public static Race Minas { get; } = new("♉", "Минас", ("Второе дыхание", "Рога"), c => (c.Str, c.Con, c.Int));
    public static Race Serpent { get; } = new(" 🦎", "Серпент", ("Гидроадаптация", "Чешуя"), c => (c.Con, c.Int, c.Wis));

    public static IReadOnlyList<Race> All { get; } = new[] { Human, Elf, Dwarf, Kitsune, Minas, Serpent };
}
