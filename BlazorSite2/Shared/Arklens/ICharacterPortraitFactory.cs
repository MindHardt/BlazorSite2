namespace BlazorSite2.Shared.Arklens;

public interface ICharacterPortraitProvider
{
	public ValueTask<byte[]?> GetPortraitFor(Character charater);
}
