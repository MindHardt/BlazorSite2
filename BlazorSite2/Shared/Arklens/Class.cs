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

	public readonly static Class Barbarian = new("😡", "Варвар", 12, 4, c => new[] { c.Str, c.Con, c.Dex, c.Wis, c.Cha, c.Int });
    public readonly static Class Bard = new("🪕", "Бард", 8, 5, c => new[] { c.Cha, c.Dex, c.Wis, c.Con, c.Str, c.Int });
    public readonly static Class BookWorm = new("🎓", "Книгочей", 6, 6, c => new[] { c.Int, c.Dex, c.Wis, c.Con, c.Cha, c.Str });
    public readonly static Class Druid = new("🍀", "Друид", 8, 3, c => new[] { c.Wis, c.Dex, c.Con, c.Cha, c.Str, c.Int }, DruidCircle.All);
    public readonly static Class Kineticist = new("☄", "Кинетик", 10, 3, c => new[] { c.Con, c.Dex, c.Str, c.Wis, c.Int, c.Cha });
    public readonly static Class Monk = new("🧘‍", "Монах", 10, 4, c => new[] { c.Dex, c.Wis, c.Str, c.Con, c.Int, c.Cha });
    public readonly static Class Paladin = new("🛡", "Паладин", 10, 3, c => new[] { c.Cha, c.Str, c.Con, c.Wis, c.Dex, c.Int }, PriestFaith.All);
    public readonly static Class Priest = new("📜", "Жрец", 8, 4, c => new[] { c.Wis, c.Con, c.Cha, c.Str, c.Dex, c.Int }, PriestFaith.All);
    public readonly static Class Ranger = new("🦅", "Следопыт", 8, 5, c => new[] { c.Dex, c.Wis, c.Con, c.Str, c.Cha, c.Int });
    public readonly static Class Rogue = new("🗡", "Разбойник", 8, 5, c => new[] { c.Dex, c.Wis, c.Str, c.Int, c.Cha, c.Con });
    public readonly static Class Warrior = new("⚔", "Воин", 10, 3, c => new[] { c.Str, c.Con, c.Dex, c.Wis, c.Cha, c.Int });
    public readonly static Class Wizard = new("📚", "Волшебник", 6, 6, c => new[] { c.Int, c.Dex, c.Con, c.Wis, c.Str, c.Cha }, WizardSchool.All);

    public readonly static IReadOnlyList<Class> All
        = new[] { Barbarian, Bard, BookWorm, Druid, Kineticist, Monk, Paladin, Priest, Ranger, Rogue, Warrior, Wizard };
}
