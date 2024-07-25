using Microsoft.AspNetCore.Components;

namespace RazorUI.Layout;

public partial class SecondaryNavMenu
{
	/// <summary>
	///		子内容
	/// </summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	[Parameter]
	public string Padding { get; set; } = "10px";

	[Parameter]
	public string GridRowGap { get; set; } = "10px";
}
