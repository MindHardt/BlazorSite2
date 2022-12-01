using BlazorSite2.Shared.Arklens.Subclasses;

namespace BlazorSite2.Shared.Arklens;
public class Class : CharacterElement
{
	private readonly Func<Character, Stat[]> _statsPriority;

	public int HpGain { get; }
    public int SkillPoints { get; }
    public IReadOnlyList<Subclass>? Subclasses { get; }
    private Class(string emoji, string name, int hpGain, int skillPoints, Func<Character, Stat[]> statsPriority, IReadOnlyList<Subclass>? subclasses = null) : base(emoji, name)
	{
		HpGain = hpGain;
		SkillPoints = skillPoints;
		Subclasses = subclasses;
		_statsPriority = statsPriority;
	}

    public IReadOnlyList<Stat> GetStatsPriorityFor(Character character) 
        => _statsPriority(character);

	public static Class Barbarian { get; } = new("😡", "Варвар", 12, 4, c => new[] { c.Str, c.Con, c.Dex, c.Wis, c.Cha, c.Int });
    public static Class Bard { get; } = new("🪕", "Бард", 8, 5, c => new[] { c.Cha, c.Dex, c.Wis, c.Con, c.Str, c.Int });
    public static Class BookWorm { get; } = new("🎓", "Книгочей", 6, 6, c => new[] { c.Int, c.Dex, c.Wis, c.Con, c.Cha, c.Str });
    public static Class Druid { get; } = new("🍀", "Друид", 8, 3, c => new[] { c.Wis, c.Dex, c.Con, c.Cha, c.Str, c.Int }, DruidCircle.All);
    public static Class Kineticist { get; } = new("☄", "Кинетик", 10, 3, c => new[] { c.Con, c.Dex, c.Str, c.Wis, c.Int, c.Cha });
    public static Class Monk { get; } = new("🧘‍", "Монах", 10, 4, c => new[] { c.Dex, c.Wis, c.Str, c.Con, c.Int, c.Cha });
    public static Class Paladin { get; } = new("🛡", "Паладин", 10, 3, c => new[] { c.Cha, c.Str, c.Con, c.Wis, c.Dex, c.Int }, PriestFaith.All);
    public static Class Priest { get; } = new("📜", "Жрец", 8, 4, c => new[] { c.Wis, c.Con, c.Cha, c.Str, c.Dex, c.Int }, PriestFaith.All);
    public static Class Ranger { get; } = new("🦅", "Следопыт", 8, 5, c => new[] { c.Dex, c.Wis, c.Con, c.Str, c.Cha, c.Int });
    public static Class Rogue { get; } = new("🗡", "Разбойник", 8, 5, c => new[] { c.Dex, c.Wis, c.Str, c.Int, c.Cha, c.Con });
    public static Class Warrior { get; } = new("⚔", "Воин", 10, 3, c => new[] { c.Str, c.Con, c.Dex, c.Wis, c.Cha, c.Int });
    public static Class Wizard { get; } = new("📚", "Волшебник", 6, 6, c => new[] { c.Int, c.Dex, c.Con, c.Wis, c.Str, c.Cha }, WizardSchool.All);

    public static IReadOnlyList<Class> All { get; } = new[] { Barbarian, Bard, BookWorm, Druid, Kineticist, Monk, Paladin, Priest, Ranger, Rogue, Warrior, Wizard };
}
