﻿using BlazorSite2.Shared.Arklens.Subclasses;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Un1ver5e.Web.III.Shared;

namespace BlazorSite2.Shared.Arklens;
public record Character : INotifyPropertyChanged
{
	private Race? race;
	private string? name;
	private Gender? gender;
	private Class? @class;
	private Alignment? alignment;
	private Subclass? subClass;


	public event PropertyChangedEventHandler? PropertyChanged;


	public Stat Str { get; } = new(Stat.MinValue, "💪", "СИЛ");
	public Stat Dex { get; } = new(Stat.MinValue, "🏃‍", "ЛВК");
	public Stat Con { get; } = new(Stat.MinValue, "🩸", "ВЫН");
	public Stat Int { get; } = new(Stat.MinValue, "🧠", "ИНТ");
	public Stat Wis { get; } = new(Stat.MinValue, "🦉", "МДР");
	public Stat Cha { get; } = new(Stat.MinValue, "👄", "ХАР");
	public Race? Race
	{
		get => race;
		set
		{
			race = value;
			ApplyRaceImpact();
			OnPropertyChanged(nameof(Race));
		}
	}
	public string? Name
	{
		get => name;
		set
		{
			name = value;
			OnPropertyChanged(nameof(Name));
		}
	}
	public Gender? Gender
	{
		get => gender;
		set
		{
			gender = value;
			OnPropertyChanged(nameof(Gender));
		}
	}
	public Class? Class
	{
		get => @class;
		set
		{
			@class = value;
			SubClass = null;
			OnPropertyChanged(nameof(Class));
		}
	}
	public Alignment? Alignment
	{
		get => alignment;
		set
		{
			alignment = value;
			OnPropertyChanged(nameof(Alignment));
		}
	}
	public Subclass? SubClass 
	{ 
		get => subClass; 
		set
		{
			subClass = value;
			OnPropertyChanged(nameof(SubClass));
		}
	}
	

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
	public void ClearRaceImpact()
	{
		foreach (Stat stat in EnumerateStats()) stat.RaceAmplified = null;
		OnPropertyChanged(nameof(Race));
	}

	private void OnPropertyChanged([CallerMemberName] string prop = "")
		=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

	public string FillSvgFile(string rawSvg)
		=> new StringBuilder(rawSvg)
		.Replace("%STR%", Str.DisplayValue.ToString())
		.Replace("%DEX%", Dex.DisplayValue.ToString())
		.Replace("%CON%", Con.DisplayValue.ToString())
		.Replace("%INT%", Int.DisplayValue.ToString())
		.Replace("%WIS%", Wis.DisplayValue.ToString())
		.Replace("%CHA%", Cha.DisplayValue.ToString())

		.Replace("%STR+%", Str.DisplayMod.AsMod())
		.Replace("%DEX+%", Dex.DisplayMod.AsMod())
		.Replace("%CON+%", Con.DisplayMod.AsMod())
		.Replace("%INT+%", Int.DisplayMod.AsMod())
		.Replace("%WIS+%", Wis.DisplayMod.AsMod())
		.Replace("%CHA+%", Cha.DisplayMod.AsMod())

		.Replace("%RACE%", Race?.ToString())
		.Replace("%RACETRAIT1%", Race?.Traits?[0])
		.Replace("%RACETRAIT2%", Race?.Traits?[1])

		.Replace("%CLASS%", Class?.ToString())
		.Replace("%SUBCLASS%", SubClass?.ToString())
		.Replace("%HPGAIN%", (Class?.HpGain + Con.DisplayMod)?.ToString())
		.Replace("%SKILLS%", (Class?.SkillPoints + Int.DisplayMod + (Race == Race.Human ? 1 : 0))?.ToString())

		.Replace("%GENDER%", Gender?.ToString())
		.Replace("%NAME%", Name)

		.Replace("%ALIGNMENT%", Alignment?.ToString())

		.ToString();
}
