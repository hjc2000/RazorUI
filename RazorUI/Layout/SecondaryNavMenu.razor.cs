using Microsoft.AspNetCore.Components;

namespace RazorUI.Layout;

/// <summary>
///		二级导航菜单。
/// </summary>
public partial class SecondaryNavMenu
{
	/// <summary>
	///		子内容
	/// </summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	/// <summary>
	///		内边距。默认：10px
	/// </summary>
	[Parameter]
	public string Padding { get; set; } = "10px";

	/// <summary>
	///		网格行间隙。默认：10px
	/// </summary>
	[Parameter]
	public string GridRowGap { get; set; } = "10px";
}
