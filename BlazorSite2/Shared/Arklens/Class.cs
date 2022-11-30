namespace BlazorSite2.Shared.Arklens;
public class Class : CharacterElement
{
    public int HpGain { get; }
    public int SkillPoints { get; }
    public IReadOnlyList<string>? Subclasses { get; }
    public Class(string emoji, string name, int hpGain, int skillPoints, params string[] subclasses) : base(emoji, name)
    {
        HpGain = hpGain;
        SkillPoints = skillPoints;
        Subclasses = subclasses.Length > 0 ? subclasses : null;
    }

    public readonly static Class Barbarian = new("😡", "Варвар", 12, 4);
    public readonly static Class Bard = new("🪕", "Бард", 8, 5);
    public readonly static Class BookWorm = new("🎓", "Книгочей", 6, 6);
    public readonly static Class Druid = new("🍀", "Друид", 8, 3, "🍀Флорилит", "🦌Зоолит", "🦂Этнолит", "🍖Декалит", "🍄Миколит");
    public readonly static Class Kineticist = new("☄", "Кинетик", 10, 3);
    public readonly static Class Monk = new("🧘‍", "Монах", 10, 4);
    public readonly static Class Paladin = new("🛡", "Паладин", 10, 3);
    public readonly static Class Priest = new("📜", "Жрец", 8, 4, "⚒️Нерасит", "🌞Солярит", "🌟Юнаит", "⚔️Аварит", "⚖️Джастарит", "⛓Мортиит", "💀Архиит", "👑Астерит", "🦷Сангиит");
    public readonly static Class Ranger = new("🦅", "Следопыт", 8, 5);
    public readonly static Class Rogue = new("🗡", "Разбойник", 8, 5);
    public readonly static Class Warrior = new("⚔", "Воин", 10, 3);
    public readonly static Class Wizard = new("📚", "Волшебник", 6, 6, "🧙‍Универсалист", "👻Аниматург", "👁‍Иллюзионист", "💥Дизраптор", "🔁Трансмутатор", "💫Релокатор", "🔮Провидец");

    public readonly static IReadOnlyList<Class> All
        = new[] { Barbarian, Bard, BookWorm, Druid, Kineticist, Monk, Paladin, Priest, Ranger, Rogue, Warrior, Wizard };
}
