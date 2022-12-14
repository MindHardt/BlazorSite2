namespace BlazorSite2.Shared.Arklens;

/// <summary>
/// A <see cref="Character"/> portrait file content in a base64 form.
/// </summary>
public class Portrait
{
	public string FileName { get; }
	public string Base64 { get; }
	public bool IsCustom { get; }

	public Portrait(string fileName, byte[] data, bool isCustom = true)
	{
		FileName = fileName;
		Base64 = Convert.ToBase64String(data);
		IsCustom = isCustom;
	}

	public static Portrait Empty { get; } = new("-", Array.Empty<byte>(), false);
}
