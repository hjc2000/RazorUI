using Microsoft.AspNetCore.Components;

namespace RazorUI.Layout;

/// <summary>
///		用于放置到 PCLayoutComponent 的左侧按钮条的导航条组件。
/// </summary>
public partial class LeftBarNav
{
	/// <summary>
	///		子内容。用来放置 LeftBarNavButton 组件。
	/// </summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }
}
