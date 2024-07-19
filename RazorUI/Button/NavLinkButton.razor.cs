using Microsoft.AspNetCore.Components;

namespace RazorUI.Button;
public partial class NavLinkButton
{
	[Parameter]
	public string Url { get; set; } = "./";

	[Parameter]
	public RenderFragment? Left { get; set; }
	[Parameter]
	public RenderFragment? Right { get; set; }
}
