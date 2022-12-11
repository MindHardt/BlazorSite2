using BlazorSite2.Shared.Arklens.Skills;
using BlazorSite2.Shared.Arklens.Stats;
using BlazorSite2.Shared.Arklens.Subclasses;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace BlazorSite2.Shared.Arklens;

[ObservableObject]
public partial class Character
{
	[ObservableProperty]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Race? _race;

	[ObservableProperty]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public string? _name;

	[ObservableProperty]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Gender? _gender;

	[ObservableProperty]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Class? _class;

	[ObservableProperty]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Alignment? _alignment;

	[ObservableProperty]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Subclass? _subclass;

	[ObservableProperty]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Portrait? _portrait;

	public StatSet Stats { get; } = new();
	public SkillSet Skills { get; } = new();

	public int Level { get; set; } = 1;

	public int? HpGain => Class?.HpGain + Stats.Con.DisplayMod;
	public int? Health => HpGain * Level;

	public int? SkillGain => Class?.SkillPoints + Stats.Int.DisplayMod + (Race == Race.Human ? 1 : 0);
	public int? Skillpoints => SkillGain * Level;

	public Character()
	{
		Stats.PropertyChanged += (_, e) => OnPropertyChanged(e);
		PropertyChanged += (_, e) =>
		{
			if (e.PropertyName is nameof(Race) && Race is not null)
				Stats.ApplyRaceImpact(Race);
		};
	}
}
