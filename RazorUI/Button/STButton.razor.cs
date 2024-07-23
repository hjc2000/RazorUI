using Microsoft.AspNetCore.Components;

namespace RazorUI.Button;

/// <summary>
///		sat 按钮
/// </summary>
public partial class STButton
{
	/// <summary>
	///		子内容
	/// </summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	/// <summary>
	///		禁用按钮
	/// </summary>
	[Parameter]
	public bool Disabled { get; set; } = false;

	/// <summary>
	///		在捕获 Parameter 的最后，捕获所有之前未捕获的 html 标签属性。
	/// </summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public Dictionary<string, object>? CaptureUnmatchedValues { get; set; }
}
