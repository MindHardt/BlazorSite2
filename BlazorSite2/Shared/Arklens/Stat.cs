using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BlazorSite2.Shared.Arklens;

[INotifyPropertyChanged]
public partial class Stat : CharacterElement
{
	public const int MinValue = 7;
	public const int MaxValue = 18;

	/// <summary>
	/// The raw value for the stat.
	/// <para>Can be in 3..18</para>
	/// </summary>
	[ObservableProperty]
	public int rawValue;

	/// <summary>
	/// Indicates whether this <see cref="Stat"/> is amplified by 
	/// the <see cref="Character.Race"/>. This may have following values:
	/// <para>
	/// <see langword="true"/> if the value is increased,
	/// <see langword="null"/> if the value is unaffected,
	/// <see langword="false"/> if the value is decreased.
	/// </para>
	/// </summary>
	[ObservableProperty]
	private bool? raceAmplified;

	/// <summary>
	/// The modifyer of the <see cref="RawValue"/>.
	/// <para>Can be in -4..+4</para>
	/// </summary>
	public int RawMod => GetMod(RawValue);

	/// <summary>
	/// The point cost of the stat.
	/// </summary>
	public int TotalCost => s_upgradeCosts[CostIndex];


	/// <summary>
	/// The complete value for the stat including <see cref="RaceAmplified"/>.
	/// <para>Can be in 1..20</para>
	/// </summary>
	public int DisplayValue => RawValue + (RaceAmplified.HasValue ? RaceAmplified.Value ? 2 : -2 : 0);
	
	/// <summary>
	/// The modifyer of the <see cref="DisplayValue"/>.
	/// <para>Can be in -5..+5</para>
	/// </summary>
	public int DisplayMod => GetMod(DisplayValue);


	/// <summary>
	/// Defines whether a point can be added to this stat.
	/// </summary>
	public bool CanIncrease => RawValue < MaxValue;

	/// <summary>
	/// Defines whether a point can be removed from the stat.
	/// </summary>
	public bool CanDecrease => RawValue > MinValue;


	/// <summary>
	/// Gets the amounts of points needed to increase the value 
	/// or <see langword="null"/> if the stat cannot get higher.
	/// </summary>
	public int? IncreaseCost => CanIncrease ? s_upgradeCosts[CostIndex + 1] - TotalCost : null;
	
	/// <summary>
	/// Gets the amounts of points needed to decrease the value 
	/// or <see langword="null"/> if the stat cannot get lower.
	/// </summary>
	public int? DecreaseCost => CanDecrease ? s_upgradeCosts[CostIndex - 1] - TotalCost : null;


	/// <summary>
	/// Attempts to increase <see cref="RawValue"/>.
	/// </summary>
	/// <returns><see langword="true"/> if <see cref="RawValue"/> is increased, 
	/// otherwise <see langword="false"/>.</returns>
	public bool TryIncrease()
	{
		if (CanIncrease)
		{
			RawValue++;
			return true;
		}
		return false;
	}

	/// <summary>
	/// Attempts to decrease <see cref="RawValue"/>.
	/// </summary>
	/// <returns><see langword="true"/> if <see cref="RawValue"/> is decreased, 
	/// otherwise <see langword="false"/>.</returns>
	public bool TryDecrease()
	{
		if (CanDecrease)
		{
			RawValue--;
			return true;
		}
		return false;
	}

	private static int GetMod(int value) => value / 2 - 5;
	public Stat(int value, string emoji, string name) : base(emoji, name)
	{
		if (value is not <= MaxValue and >= MinValue)
			throw new ArgumentOutOfRangeException($"Value must be in range {MinValue}..{MaxValue}.");
		RawValue = value;
	}

	private int CostIndex => RawValue - MinValue;
	private static readonly int[] s_upgradeCosts =
	{ 0, 2, 3,   4, 5, 6,   7, 9, 11,   14, 17, 21 };
}
