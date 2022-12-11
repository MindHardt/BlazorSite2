using System.Collections;

namespace BlazorSite2.Shared.Arklens.Skills
{
	public class SkillSet : IEnumerable<Skill>
	{
		private readonly IReadOnlyList<Skill> _skills;

		public Skill Acrobatics { get; } = new("🤸‍", "Акробатика", c => c.Dex, true, false);
		public Skill Climbing { get; } = new("🧗", "Лазание", c => c.Str, true, false);
		public Skill Diplomacy { get; } = new("🗣", "Переговоры", c => c.Cha, false, false);
		public Skill KnowledgeDungeons { get; } = new("🕯", "Зн. Подземелий", c => c.Int, false, true);
		public Skill KnowledgeMagic { get; } = new("📚", "Зн. Магии", c => c.Int, false, true);
		public Skill KnowledgeNature { get; } = new("🏞", "Зн. Природы", c => c.Int, false, true);
		public Skill KnowledgeWorld { get; } = new("🌎", "Зн. Мира", c => c.Int, false, true);
		public Skill KnowledgeReligion { get; } = new("✝️", "Зн. Религии", c => c.Int, false, true);
		public Skill Mechanics { get; } = new("🛠", "Механика", c => c.Dex, false, true);
		public Skill Medicine { get; } = new("🩹", "Медицина", c => c.Wis, false, false);
		public Skill Riding { get; } = new("🏇", "Верховая езда", c => c.Dex, false, false);
		public Skill Stealth { get; } = new("🕵", "Скрытность", c => c.Dex, true, false);
		public Skill Survival { get; } = new("🏕", "Выживание", c => c.Wis, false, false);
		public Skill Swimming { get; } = new("🏊", "Плавание", c => c.Str, true, false);

		public SkillSet()
		{
			_skills = new[] 
			{ 
				Acrobatics, Riding, Survival, Diplomacy, KnowledgeMagic, KnowledgeWorld, 
				KnowledgeReligion, KnowledgeDungeons, KnowledgeNature, Climbing,
				Mechanics, Medicine, Swimming, Stealth,
			};
		}

		public IEnumerator<Skill> GetEnumerator()
			=> _skills.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
			=> _skills.GetEnumerator();
	}
}
