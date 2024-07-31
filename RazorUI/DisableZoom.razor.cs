using Microsoft.JSInterop;

namespace RazorUI;

/// <summary>
///		用于禁用缩放的组件。
///		只要将本组件的标签放置，就能禁止缩放。
/// </summary>
public partial class DisableZoom
{
	private IJSObjectReference moudel = default!;

	/// <summary>
	///		初始化
	/// </summary>
	/// <returns></returns>
	protected override async Task OnInitializedAsync()
	{
		moudel = await JS.InvokeAsync<IJSObjectReference>("import",
			"./_content/RazorUI/DisableZoom.razor.js");

		await moudel.InvokeVoidAsync("DisableZoom");
	}
}
