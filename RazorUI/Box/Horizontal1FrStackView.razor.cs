using Microsoft.AspNetCore.Components;

namespace RazorUI.Box;

/// <summary>
///		横向的均分每一列宽度的堆栈。每一列的网格中的元素居中对齐。
/// </summary>
public partial class Horizontal1FrStackView
{
	/// <summary>
	///		子内容
	/// </summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	/// <summary>
	///		列数。默认：2
	/// </summary>
	/// <remarks>
	///		<br/>* 由于 css 的限制，列数无法像行数那样自动适应元素数量。
	///		<br/>* 本组件默认的 ColumnCount 是 2，如果超过 2 个元素，会自动跑到下一行去，
	///			   而不会产生第 3 列。唯一的方法就是显式声明你需要几列。
	/// </remarks>
	[Parameter]
	public int ColumnCount { get; set; } = 2;

	/// <summary>
	///		间隙。默认：1em
	/// </summary>
	[Parameter]
	public string Gap { get; set; } = "1em";

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
}
