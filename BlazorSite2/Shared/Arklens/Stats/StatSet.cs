using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections;
using Un1ver5e.Web.III.Shared;

namespace BlazorSite2.Shared.Arklens.Stats
{
	[ObservableObject]
	public partial class StatSet : IEnumerable<Stat>
	{
		private readonly IReadOnlyList<Stat> stats;

		public Stat Str { get; } = new(Stat.MinValue, "💪", "СИЛ");
		public Stat Dex { get; } = new(Stat.MinValue, "🏃‍", "ЛВК");
		public Stat Con { get; } = new(Stat.MinValue, "🩸", "ВЫН");
		public Stat Int { get; } = new(Stat.MinValue, "🧠", "ИНТ");
		public Stat Wis { get; } = new(Stat.MinValue, "🦉", "МДР");
		public Stat Cha { get; } = new(Stat.MinValue, "👄", "ХАР");

		public StatSet()
		{
			stats = new[] { Str, Dex, Con, Int, Wis, Cha };
			foreach (Stat stat in this)
				stat.PropertyChanged += (_, e) => OnPropertyChanged(e);
		}

		public IEnumerator<Stat> GetEnumerator()
			=> stats.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
			=> stats.GetEnumerator();

		/// <summary>
		/// Applies <see cref="Race"/> impact of <paramref name="race"/>
		/// to this <see cref="StatSet"/> or clears any <see cref="Race"/>
		/// impact if <see cref="race"/> is <see langword="null"/>.
		/// </summary>
		/// <param name="race"></param>
		public void ApplyRaceImpact(Race? race)
		{
			ClearRaceImpact();
			var impact = race?.GetRaceImpactFor(this);
			if (impact is null) return;
			impact.Value.amp1.RaceAmplified = true;
			impact.Value.amp2.RaceAmplified = true;
			impact.Value.red.RaceAmplified = false;
		}

		/// <summary>
		/// Applies positive <see cref="Race"/> bonus to <paramref name="stat"/>
		/// and sets other <see cref="Stat"/>s to neutral state.
		/// </summary>
		/// <param name="stat"></param>
		public void ApplyRaceImpact(string? statName)
		{
			ClearRaceImpact();
			Stat? stat = this.GetByName(statName);
			if (stat is not null)
				stat.RaceAmplified = true;
		}

		private void ClearRaceImpact()
		{
			foreach (Stat stat in this) stat.RaceAmplified = null;
		}
	}
}
