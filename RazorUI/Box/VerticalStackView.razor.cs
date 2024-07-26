using Microsoft.AspNetCore.Components;

namespace RazorUI.Box;

/// <summary>
///		垂直堆叠的堆栈视图。
/// </summary>
public partial class VerticalStackView
{
	/// <summary>
	///		子内容
	/// </summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	/// <summary>
	///		行间隙。默认：0
	/// </summary>
	[Parameter]
	public string RowGap { get; set; } = "0";

	/// <summary>
	///		溢出行为。默认：auto
	/// </summary>
	[Parameter]
	public string Overflow { get; set; } = "auto";

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
	///		对齐每一行的网格线。默认：start
	/// </summary>
	[Parameter]
	public string AlignContent { get; set; } = "start";

	/// <summary>
	///		对齐每一行的网格线中的内容。默认：stretch
	/// </summary>
	[Parameter]
	public string AlignItems { get; set; } = "stretch";
}
