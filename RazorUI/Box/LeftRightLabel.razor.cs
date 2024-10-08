﻿using Microsoft.AspNetCore.Components;

namespace RazorUI.Box;

/// <summary>
///		左边宽度是 max-content，右边宽度是 1fr 的 label。
/// </summary>
public partial class LeftRightLabel
{
	/// <summary>
	///		左内容。
	/// </summary>
	[Parameter]
	public RenderFragment? Left { get; set; }

	/// <summary>
	///		右内容。
	/// </summary>
	[Parameter]
	public RenderFragment? Right { get; set; }

	/// <summary>
	///		列模板。默认：max-content 1fr
	/// </summary>
	[Parameter]
	public string ColumnTemplate { get; set; } = "max-content 1fr";

	/// <summary>
	///		列间隙。默认：5px
	/// </summary>
	[Parameter]
	public string ColumnGap { get; set; } = "5px";

	/// <summary>
	///		宽度。默认：100%
	/// </summary>
	[Parameter]
	public string Width { get; set; } = "100%";
	/// <summary>
	///		高度。默认：auto
	/// </summary>
	[Parameter]
	public string Height { get; set; } = "auto";
}
