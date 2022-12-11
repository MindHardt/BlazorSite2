using BlazorSite2.Shared.Arklens.Skills;
using BlazorSite2.Shared.Arklens.Stats;
using BlazorSite2.Shared.Arklens.Subclasses;

namespace BlazorSite2.Shared.Arklens;
public class Class : CharacterElement
{
    private Func<StatSet, Stat[]> StatsPriority { get; init; } = null!;
    private Func<SkillSet, Skill[]> ClassSkills { get; init; } = null!;

	public int HpGain { get; }
    public int SkillPoints { get; }
    public IReadOnlyList<Subclass>? Subclasses { get; init; }
    private Class(string emoji, string name, int hpGain, int skillPoints) : base(emoji, name)
	{
		HpGain = hpGain;
		SkillPoints = skillPoints;
	}

    public IReadOnlyList<Skill> GetClassSkills(Character character)
        => ClassSkills(character.Skills);
    public IReadOnlyList<Stat> GetStatsPriority(Character character) 
        => StatsPriority(character.Stats);

	public static Class Barbarian { get; } = new("😡", "Варвар", 12, 4)
    {
        StatsPriority = (StatSet c) => new[] { c.Str, c.Con, c.Dex, c.Wis, c.Cha, c.Int },
        ClassSkills = (SkillSet c) => new[] { c.Acrobatics, c.Climbing, c.KnowledgeDungeons, c.Riding, c.Survival, c.Swimming },
	};
    public static Class Bard { get; } = new("🪕", "Бард", 8, 5)
    {
        StatsPriority = (StatSet c) => new[] { c.Cha, c.Dex, c.Wis, c.Con, c.Str, c.Int },
        ClassSkills = (SkillSet c) => c.ToArray(),
	};
    public static Class BookWorm { get; } = new("🎓", "Книгочей", 6, 6)
    {
        StatsPriority = (StatSet c) => new[] { c.Int, c.Dex, c.Wis, c.Con, c.Cha, c.Str },
        ClassSkills = (SkillSet c) => new[] { c.KnowledgeDungeons, c.KnowledgeMagic, c.KnowledgeNature, c.KnowledgeReligion, c.KnowledgeWorld, c.Mechanics, c.Medicine, c.Survival },
	};
    public static Class Druid { get; } = new("🍀", "Друид", 8, 3)
    {
        StatsPriority = (StatSet c) => new[] { c.Wis, c.Dex, c.Con, c.Cha, c.Str, c.Int },
        ClassSkills = (SkillSet c) => new[] { c.Climbing, c.KnowledgeNature, c.KnowledgeWorld, c.Medicine, c.Riding, c.Stealth, c.Survival, c.Swimming },
        Subclasses = DruidCircle.All,
	};
    public static Class Kineticist { get; } = new("☄", "Кинетик", 10, 3)
    {
        StatsPriority = (StatSet c) => new[] { c.Con, c.Dex, c.Str, c.Wis, c.Int, c.Cha },
        ClassSkills = (SkillSet c) => new[] { c.Acrobatics, c.Climbing, c.KnowledgeMagic, c.KnowledgeWorld, c.Survival, c.Swimming },
	};
    public static Class Monk { get; } = new("🧘‍", "Монах", 10, 4)
    {
        StatsPriority = (StatSet c) => new[] { c.Dex, c.Wis, c.Str, c.Con, c.Int, c.Cha },
        ClassSkills = (SkillSet c) => new[] { c.Acrobatics, c.Climbing, c.KnowledgeWorld, c.Stealth },
	};
    public static Class Paladin { get; } = new("🛡", "Паладин", 10, 3)
    {
        StatsPriority = (StatSet c) => new[] { c.Cha, c.Str, c.Con, c.Wis, c.Dex, c.Int },
        ClassSkills= (SkillSet c) => new[] { c.Diplomacy, c.KnowledgeDungeons, c.KnowledgeReligion, c.Medicine, c.Riding },
        Subclasses = PriestFaith.All,
	};
    public static Class Priest { get; } = new("📜", "Жрец", 8, 4)
    {
        StatsPriority = (StatSet c) => new[] { c.Wis, c.Con, c.Cha, c.Str, c.Dex, c.Int },
        ClassSkills = (SkillSet c) => new[] { c.Diplomacy, c.KnowledgeDungeons, c.KnowledgeReligion, c.KnowledgeWorld, c.Medicine, c.Riding },
        Subclasses = PriestFaith.All,
    };
    public static Class Ranger { get; } = new("🦅", "Следопыт", 8, 5)
    {
        StatsPriority = (StatSet c) => new[] { c.Dex, c.Wis, c.Con, c.Str, c.Cha, c.Int },
        ClassSkills = (SkillSet c) => new[] { c.Acrobatics, c.Climbing, c.KnowledgeDungeons, c.KnowledgeNature, c.KnowledgeWorld, c.Stealth, c.Survival, c.Swimming },
	};
    public static Class Rogue { get; } = new("🗡", "Разбойник", 8, 5)
    {
        StatsPriority = (StatSet c) => new[] { c.Dex, c.Wis, c.Str, c.Int, c.Cha, c.Con },
        ClassSkills = (SkillSet c) => new[] { c.Acrobatics, c.Climbing, c.Diplomacy, c.KnowledgeWorld, c.Mechanics, c.Stealth, c.Survival },
    };
    public static Class Warrior { get; } = new("⚔", "Воин", 10, 3)
    {
        StatsPriority = (StatSet c) => new[] { c.Str, c.Con, c.Dex, c.Wis, c.Cha, c.Int },
        ClassSkills = (SkillSet c) => new[] { c.KnowledgeDungeons, c.Riding, c.Swimming },
    };
    public static Class Wizard { get; } = new("📚", "Волшебник", 6, 6)
    {
        StatsPriority = (StatSet c) => new[] { c.Int, c.Dex, c.Con, c.Wis, c.Str, c.Cha },
        ClassSkills = (SkillSet c) => new[] { c.KnowledgeDungeons, c.KnowledgeMagic, c.KnowledgeNature, c.KnowledgeReligion, c.KnowledgeWorld },
        Subclasses = WizardSchool.All,
    };

    public static IReadOnlyList<Class> All { get; } = new[] { Barbarian, Bard, BookWorm, Druid, Kineticist, Monk, Paladin, Priest, Ranger, Rogue, Warrior, Wizard };
}
