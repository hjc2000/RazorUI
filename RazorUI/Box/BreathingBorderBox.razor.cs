using Microsoft.AspNetCore.Components;

namespace RazorUI.Box;

/// <summary>
///		带有呼吸灯特效的边框。
/// </summary>
/// <remarks>
///		是个盒子，把其他盒子放到本盒子里，就可以具有呼吸边框了。
/// </remarks>
public partial class BreathingBorderBox
{
	/// <summary>
	///		子内容。
	/// </summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	/// <summary>
	///		宽度。默认：100%
	/// </summary>
	[Parameter]
	public string Width { get; set; } = "100%";

	/// <summary>
	///		高度。默认：100%
	/// </summary>
	[Parameter]
	public string Height { get; set; } = "100%";

	/// <summary>
	///		内边距。默认：0
	/// </summary>
	[Parameter]
	public string Padding { get; set; } = "0";

	/// <summary>
	///		溢出行为。默认：hidden
	/// </summary>
	[Parameter]
	public string Overflow { get; set; } = "hidden";
}
