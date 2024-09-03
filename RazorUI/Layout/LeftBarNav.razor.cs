using Microsoft.AspNetCore.Components;

namespace RazorUI.Layout;

/// <summary>
///		左侧边栏导航条。
///		用来放置到 PCLayoutComponent 的 LeftBarContent 中的组件。
/// </summary>
public partial class LeftBarNav
{
	/// <summary>
	///		用来放置 LeftBarNavButton
	/// </summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }
}
