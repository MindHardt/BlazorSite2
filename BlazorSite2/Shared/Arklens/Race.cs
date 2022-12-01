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

	public readonly static Race Human = new("🧑", "Человек", ("Умелец", "Доп. черта"), _ => null);
    public readonly static Race Elf = new("🧝", "Эльф", ("Инсомния", "Эльфийская чуткость"), c => (c.Dex, c.Int, c.Con));
    public readonly static Race Dwarf = new("🧔", "Дварф", ("Каменная стойкость", "Неостановимый"), c => (c.Con, c.Wis, c.Cha));
    public readonly static Race Kitsune = new("🦊", "Кицуне", ("Регенерация", "Когти"), c => (c.Dex, c.Cha, c.Str));
    public readonly static Race Minas = new("♉", "Минас", ("Второе дыхание", "Рога"), c => (c.Str, c.Con, c.Int));
    public readonly static Race Serpent = new(" 🦎", "Серпент", ("Гидроадаптация", "Чешуя"), c => (c.Con, c.Int, c.Wis));

    public readonly static IReadOnlyList<Race> All
        = new[] { Human, Elf, Dwarf, Kitsune, Minas, Serpent };
}
