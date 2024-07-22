using Microsoft.AspNetCore.Components;

namespace RazorUI.Layout;

public partial class LeftBarNav
{
	[Parameter]
	public RenderFragment? ChildContent { get; set; }
}
