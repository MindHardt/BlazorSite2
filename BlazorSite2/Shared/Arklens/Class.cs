namespace BlazorSite2.Shared.Arklens
{
    public class Class : CharacterElement
    {
        public int HpGain { get; }
        public int SkillPoints { get; }
        public string[]? Subclasses { get; }
        public Class(string emoji, string name, int hpGain, int skillPoints, params string[] subclasses) : base(emoji, name)
        {
            HpGain = hpGain;
            SkillPoints = skillPoints;
            Subclasses = subclasses.Length > 0 ? subclasses : null;
        }

        public static Class Barbarian => new("😡", "Варвар", 12, 4);
        public static Class Bard => new("🪕", "Бард", 8, 5);
        public static Class BookWorm => new("🎓", "Книгочей", 6, 6);
        public static Class Druid => new("🍀", "Друид", 8, 3, "🍀Флорилит", "🦌Зоолит", "🦂Этнолит", "🍖Декалит", "🍄Миколит");
        public static Class Kineticist => new("☄", "Кинетик", 10, 3);
        public static Class Monk => new("🧘‍", "Монах", 10, 4);
        public static Class Paladin => new("🛡", "Паладин", 10, 3);
        public static Class Priest => new("📜", "Жрец", 8, 4, "⚒️Нерасит", "🌞Солярит", "🌟Юнаит", "⚔️Аварит", "⚖️Джастарит", "⛓Мортиит", "💀Архиит", "👑Астерит", "🦷Сангиит");
        public static Class Ranger => new("🦅", "Следопыт", 8, 5);
        public static Class Rogue => new("🗡", "Разбойник", 8, 5);
        public static Class Warrior => new("⚔", "Воин", 10, 3);
        public static Class Wizard => new("📚", "Волшебник", 6, 6, "🧙‍Универсалист", "👻Аниматург", "👁‍Иллюзионист", "💥Дизраптор", "🔁Трансмутатор", "💫Релокатор", "🔮Провидец");

        public static Class[] All
            => new[] { Barbarian, Bard, BookWorm, Druid, Kineticist, Monk, Paladin, Priest, Ranger, Rogue, Warrior, Wizard };
    }
}
