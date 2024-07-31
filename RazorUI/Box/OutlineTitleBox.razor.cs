using Microsoft.AspNetCore.Components;

namespace RazorUI.Box;

/// <summary>
///		具有轮廓线的标题盒子。
/// </summary>
public partial class OutlineTitleBox
{
	/// <summary>
	///		子内容。
	/// </summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }
}
