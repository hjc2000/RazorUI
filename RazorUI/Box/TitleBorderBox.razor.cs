using Microsoft.AspNetCore.Components;

namespace RazorUI.Box;

/// <summary>
///		具有标题的边框盒子。
/// </summary>
public partial class TitleBorderBox
{
	/// <summary>
	///		标题
	/// </summary>
	[Parameter]
	public RenderFragment? Title { get; set; }

	/// <summary>
	///		内容
	/// </summary>
	[Parameter]
	public RenderFragment? Content { get; set; }
}
