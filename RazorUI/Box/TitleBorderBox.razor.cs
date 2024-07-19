using Microsoft.AspNetCore.Components;

namespace RazorUI.Box;
public partial class TitleBorderBox
{
	[Parameter]
	public RenderFragment? Title { get; set; }

	[Parameter]
	public RenderFragment? Content { get; set; }
}
