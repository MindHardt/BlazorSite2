using BlazorSite2.Shared.Arklens;

namespace BlazorSite2.Client.Services;

public class FilePortraitProvider : ICharacterPortraitProvider
{
	private readonly HttpClient http;

	public FilePortraitProvider(HttpClient http)
	{
		this.http = http;
	}

	public async ValueTask<byte[]?> GetPortraitFor(Character charater)
	{
		if (charater.Race is null || charater.Gender is null) 
			return null;

		string filePath = $"files/portraits/{charater.Race.Name}.{charater.Gender.Name[0]}.png";
		try
		{
			return await http.GetByteArrayAsync(filePath);
		}
		catch
		{
			return null;
		}
	}
}
