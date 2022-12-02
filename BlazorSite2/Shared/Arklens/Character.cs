using BlazorSite2.Shared.Arklens.Subclasses;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
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
	public void ClearRaceImpact()
	{
		foreach (Stat stat in EnumerateStats()) stat.RaceAmplified = null;
		OnPropertyChanged(nameof(Race));
	}


	public Character()
	{
		foreach (Stat stat in EnumerateStats())
		{
			stat.PropertyChanged += (_, _) => OnPropertyChanged(nameof(stat));
		}
	}


	private void OnPropertyChanged([CallerMemberName] string prop = "")
		=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

	private string GetRegexText(Match match, byte[] portraitFile)
	{
		object? value = match.Value switch
		{
			"{STR}" => Str.DisplayValue,
			"{DEX}" => Dex.DisplayValue,
			"{CON}" => Con.DisplayValue,
			"{INT}" => Int.DisplayValue,
			"{WIS}" => Wis.DisplayValue,
			"{CHA}" => Cha.DisplayValue,

			"{STR+}" => Str.DisplayMod.AsMod(),
			"{DEX+}" => Dex.DisplayMod.AsMod(),
			"{CON+}" => Con.DisplayMod.AsMod(),
			"{INT+}" => Int.DisplayMod.AsMod(),
			"{WIS+}" => Wis.DisplayMod.AsMod(),
			"{CHA+}" => Cha.DisplayMod.AsMod(),

			"{RACE}" => Race,
			"{RACETRAIT1}" => Race?.Traits?[0],
			"{RACETRAIT2}" => Race?.Traits?[1],
			"{CLASS}" => Class,
			"{SUBCLASS}" => SubClass,
			"{HPGAIN}" => HpGain,
			"{SKILLS}" => Skillpoints,
			"{GENDER}" => Gender,
			"{NAME}" => Name,
			"{ALIGNMENT}" => Alignment,
			"{PORTRAIT}" => Convert.ToBase64String(portraitFile),
			_ => null,
		};
		return value?.ToString() ?? string.Empty;
	}
	public string FillSvgFile(string rawSvg, byte[] portraitFile)
		=> Regex.Replace(rawSvg, "{.*?}", m => GetRegexText(m, portraitFile));
	//=> new StringBuilder(rawSvg)
	//.ReplaceSingle("{STR}", rawSvg, Str.DisplayValue)
	//.ReplaceSingle("{DEX}", rawSvg, Dex.DisplayValue)
	//.ReplaceSingle("{CON}", rawSvg, Con.DisplayValue)
	//.ReplaceSingle("{INT}", rawSvg, Int.DisplayValue)
	//.ReplaceSingle("{WIS}", rawSvg, Wis.DisplayValue)
	//.ReplaceSingle("{CHA}", rawSvg, Cha.DisplayValue)
	//.ReplaceSingle("{STR+}", rawSvg, Str.DisplayMod.AsMod())
	//.ReplaceSingle("{DEX+}", rawSvg, Dex.DisplayMod.AsMod())
	//.ReplaceSingle("{CON+}", rawSvg, Con.DisplayMod.AsMod())
	//.ReplaceSingle("{INT+}", rawSvg, Int.DisplayMod.AsMod())
	//.ReplaceSingle("{WIS+}", rawSvg, Wis.DisplayMod.AsMod())
	//.ReplaceSingle("{CHA+}", rawSvg, Cha.DisplayMod.AsMod())

	//.ReplaceSingle("{RACE}", rawSvg, Race)
	//.ReplaceSingle("{RACETRAIT1}", rawSvg, Race?.Traits?[0])
	//.ReplaceSingle("{RACETRAIT2}", rawSvg, Race?.Traits?[1])

	//.ReplaceSingle("{CLASS}", rawSvg, Class)
	//.ReplaceSingle("{SUBCLASS}", rawSvg, SubClass)
	//.ReplaceSingle("{HPGAIN}", rawSvg, HpGain)
	//.ReplaceSingle("{SKILLS}", rawSvg, Skillpoints)

	//.ReplaceSingle("{GENDER}", rawSvg, Gender)
	//.ReplaceSingle("{NAME}", rawSvg, Name)

	//.ReplaceSingle("{ALIGNMENT}", rawSvg, Alignment)

	//.ToString();
}
