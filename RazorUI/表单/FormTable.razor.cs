using Microsoft.AspNetCore.Components;

namespace RazorUI.表单;

/// <summary>
///		表单
/// </summary>
public partial class FormTable
{
	/// <summary>
	///		表单头部。
	/// </summary>
	[Parameter]
	public RenderFragment? Head { get; set; }

	/// <summary>
	///		表单主体。
	/// </summary>
	[Parameter]
	public RenderFragment? Body { get; set; }

	/// <summary>
	///		表单脚部。
	/// </summary>
	[Parameter]
	public RenderFragment? Foot { get; set; }

	/// <summary>
	///		表单整体宽度。默认：100%
	/// </summary>
	[Parameter]
	public string Width { get; set; } = "100%";
	/// <summary>
	///		表单整体高度。默认：100%
	/// </summary>
	[Parameter]
	public string Height { get; set; } = "100%";

	/// <summary>
	///		表单头部内边距。默认：0
	/// </summary>
	[Parameter]
	public string HeadPadding { get; set; } = "0";

	/// <summary>
	///		表单身体内边距。默认：0
	/// </summary>
	[Parameter]
	public string BodyPadding { get; set; } = "0";

	/// <summary>
	///		表单脚部内边距。默认：0
	/// </summary>
	[Parameter]
	public string FootPadding { get; set; } = "0";

	/// <summary>
	///		表单身体列间隙。默认：1em
	/// </summary>
	[Parameter]
	public string BodyColumnGap { get; set; } = "1em";

	/// <summary>
	///		表单身体行间隙。默认：15px
	/// </summary>
	[Parameter]
	public string BodyRowGap { get; set; } = "15px";

	/// <summary>
	///		表单身体网格的列模板，默认："max-content 1fr"。
	/// </summary>
	[Parameter]
	public string BodyGridTemplateColumns { get; set; } = "max-content 1fr";

	/// <summary>
	///		表单身体列的对齐方式。默认：stretch
	/// </summary>
	[Parameter]
	public string BodyJustifyContent { get; set; } = "stretch";

	/// <summary>
	///		表单身体列的网格线中的元素的对齐方式。默认：stretch
	/// </summary>
	[Parameter]
	public string BodyJustifyItems { get; set; } = "stretch";

	/// <summary>
	///		表单身体行的对齐方式。默认：start
	/// </summary>
	[Parameter]
	public string BodyAlignContent { get; set; } = "start";

	/// <summary>
	///		表单身体行网格线内的元素的对齐方式。默认：stretch
	/// </summary>
	[Parameter]
	public string BodyAlignItems { get; set; } = "stretch";

	/// <summary>
	///		表单身体溢出行为。默认：auto
	/// </summary>
	[Parameter]
	public string BodyOverflow { get; set; } = "auto";

	/// <summary>
	///		表单头部底部边框样式。默认：#583131 2px dashed
	/// </summary>
	[Parameter]
	public string HeadBorderBottom { get; set; } = "#583131 2px dashed";
}
