using Microsoft.AspNetCore.Components;

namespace RazorUI.Box;
public partial class StickyHeaderScrollView
{
	[Parameter]
	public RenderFragment? Header { get; set; }

	[Parameter]
	public RenderFragment? Content { get; set; }

	[Parameter]
	public string HeaderPadding { get; set; } = "0";
	[Parameter]
	public string ContentPadding { get; set; } = "0";
}
