namespace BlazorSite2.Shared.Arklens;

public class Portrait
{
	public string FileName { get; }
	public byte[] Binary { get; }
	public string Base64 { get; }
	public bool IsCustom { get; }

	public Portrait(string fileName, byte[] data, bool isCustom = true)
	{
		FileName = fileName;
		Binary = data;
		Base64 = Convert.ToBase64String(data);
		IsCustom = isCustom;
	}

	public static Portrait Empty { get; } = new("-", Array.Empty<byte>(), false);
}
