using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlazorSite2.Shared.Arklens;

public class Portrait : INotifyPropertyChanged
{
	private byte[] binary = null!;
	private string base64 = null!;
	private bool isCustom = false;

	public event PropertyChangedEventHandler? PropertyChanged;

	public byte[] Binary
	{
		get => binary;
		set
		{
			binary = value;
			base64 = Convert.ToBase64String(binary);
			OnPropertyChanged(nameof(Binary));
		}
	}
	public string Base64 => base64;
	public bool IsCustom => isCustom;

	public Portrait()
	{
		Binary = Array.Empty<byte>();
	}

	public void TryUpdate(Character character, Func<Character, byte[]?> factory)
	{
		if (IsCustom is false)
		{
			byte[]? data = factory(character);

			if (data is not null)
			{
				Binary = data;
				isCustom = false;
			}
		}
	}
	public void SetCustomPortrait(byte[] image)
	{
		Binary= image;
		isCustom = true;
	}
	private void OnPropertyChanged([CallerMemberName] string prop = "")
	=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}
