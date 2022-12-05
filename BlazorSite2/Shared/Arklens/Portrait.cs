using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlazorSite2.Shared.Arklens;

public class Portrait
{
	private byte[] binary = null!;
	private string base64 = null!;

	public byte[] Binary
	{
		get => binary;
		set
		{
			binary = value;
			base64 = Convert.ToBase64String(binary);
		}
	}
	public string Base64 => base64;
	public bool IsCustom { get; }

	public Portrait(byte[] data, bool isCustom = true)
	{
		Binary = data;
		IsCustom = isCustom;
	}

	public static Portrait Empty { get; } = new(Array.Empty<byte>(), false);
}
