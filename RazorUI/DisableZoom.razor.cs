using Microsoft.JSInterop;

namespace RazorUI;

public partial class DisableZoom
{
	private IJSObjectReference moudel = default!;
	protected override async Task OnInitializedAsync()
	{
		moudel = await JS.InvokeAsync<IJSObjectReference>("import",
														  "./_content/RazorUI/DisableZoom.razor.js");

		await moudel.InvokeVoidAsync("DisableZoom");
	}
}
