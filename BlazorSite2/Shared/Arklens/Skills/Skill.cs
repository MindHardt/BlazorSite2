using BlazorSite2.Shared.Arklens.Stats;

namespace BlazorSite2.Shared.Arklens.Skills
{
	public class Skill : CharacterElement
	{
		private readonly Func<StatSet, Stat> _stat;
		public int Points { get; set; }
		public bool RequiresLearning { get; }
		public bool AffectedByArmor { get; }
		public Stat GetStat(Character character) => _stat(character.Stats);
		public bool? IsClass(Character character) => character.Class?.GetClassSkills(character).Contains(this);
		public int? CalculateValueFor(Character character)
		{
			if (RequiresLearning && Points == 0) return null;
			int value = Points
				+ GetStat(character).DisplayMod
				+ (Points > 0 && IsClass(character) is true ? 3 : 0);
			Console.WriteLine($"{Emoji}_{Points}_{value}");
			return value;
		}
		public Skill(string emoji, string name, Func<StatSet, Stat> stat, bool armor = false, bool learning = false) : base(emoji, name)
		{
			_stat = stat;
			RequiresLearning = learning; 
			AffectedByArmor = armor;
		}
	}
}
