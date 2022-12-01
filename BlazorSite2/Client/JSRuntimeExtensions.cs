using Microsoft.JSInterop;

namespace BlazorSite2.Client;

public static class JSRuntimeExtensions
{
	public static ValueTask AlertAsync(this IJSRuntime js, string text) 
		=> js.InvokeVoidAsync("alert", text);

	public static ValueTask<string> PromptAsync(this IJSRuntime js, string text) 
		=> js.InvokeAsync<string>("prompt", text);

	public static ValueTask<bool> ConfirmAsync(this IJSRuntime js, string text) 
		=> js.InvokeAsync<bool>("confirm", text);
}