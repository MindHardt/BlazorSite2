using BlazorSite2.Shared.Arklens.Subclasses;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlazorSite2.Shared.Arklens;

[ObservableObject]
public partial class Character
{
	[ObservableProperty]
	[AccessedThroughProperty(nameof(Race))]
	public Race? _race;

	[ObservableProperty]
	[AccessedThroughProperty(nameof(Name))]
	public string? _name;

	[ObservableProperty]
	[AccessedThroughProperty(nameof(Gender))]
	public Gender? _gender;

	[ObservableProperty]
	[AccessedThroughProperty(nameof(Class))]
	public Class? _class;

	[ObservableProperty]
	[AccessedThroughProperty(nameof(Alignment))]
	public Alignment? _alignment;

	[ObservableProperty]
	[AccessedThroughProperty(nameof(Subclass))]
	public Subclass? _subclass;

	[ObservableProperty]
	[AccessedThroughProperty(nameof(Portrait))]
	public Portrait? _portrait;


	public Stat Str { get; } = new(Stat.MinValue, "💪", "СИЛ");
	public Stat Dex { get; } = new(Stat.MinValue, "🏃‍", "ЛВК");
	public Stat Con { get; } = new(Stat.MinValue, "🩸", "ВЫН");
	public Stat Int { get; } = new(Stat.MinValue, "🧠", "ИНТ");
	public Stat Wis { get; } = new(Stat.MinValue, "🦉", "МДР");
	public Stat Cha { get; } = new(Stat.MinValue, "👄", "ХАР");


	public int? HpGain => Class?.HpGain + Con.DisplayMod;
	public int? Skillpoints => Class?.SkillPoints + Int.DisplayMod + (Race == Race.Human ? 1 : 0);


	/// <summary>
	/// Gets all six character stats.
	/// </summary>
	/// <returns></returns>
	public IReadOnlyList<Stat> EnumerateStats()
		=> new[] { Str, Dex, Con, Int, Wis, Cha };


	private void ApplyRaceImpact()
	{
		ClearRaceImpact();
		var impact = Race?.GetRaceImpactFor(this);
		if (impact is null) return;
		impact.Value.amp1.RaceAmplified = true;
		impact.Value.amp2.RaceAmplified = true;
		impact.Value.red.RaceAmplified = false;
	}
	private void ClearRaceImpact()
	{
		foreach (Stat stat in EnumerateStats()) stat.RaceAmplified = null;
	}


	public Character()
	{
		foreach (Stat stat in EnumerateStats())
		{
			stat.PropertyChanged += (_, _) => OnPropertyChanged(nameof(stat));
		}
		PropertyChanged += (_, e) =>
		{
			if (e.PropertyName == nameof(Race)) ApplyRaceImpact();
		};
	}
}
