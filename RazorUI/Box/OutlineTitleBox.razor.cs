using Microsoft.AspNetCore.Components;

namespace RazorUI.Box;
public partial class OutlineTitleBox
{
	[Parameter]
	public RenderFragment? ChildContent { get; set; }
}
