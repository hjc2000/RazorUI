using Microsoft.AspNetCore.Components;

namespace RazorUI.表单;

/// <summary>
///		表单展开按钮
/// </summary>
public partial class FormExpandButton
{
	/// <summary>
	///		展开状态
	/// </summary>
	[Parameter]
	public FormExpandState ExpandState { get; set; }

	/// <summary>
	///		展开状态发生变化时的回调
	/// </summary>
	[Parameter]
	public EventCallback<FormExpandState> ExpandStateChanged { get; set; }

	private async Task ChangeExpandStateAsync()
	{
		if (ExpandState == FormExpandState.Expand)
		{
			await ExpandStateChanged.InvokeAsync(FormExpandState.Collapse);
		}
		else
		{
			await ExpandStateChanged.InvokeAsync(FormExpandState.Expand);
		}
	}

	private string HorverTitle
	{
		get
		{
			if (ExpandState == FormExpandState.Expand)
			{
				return "折叠";
			}
			else
			{
				return "展开";
			}
		}
	}
}

/// <summary>
///		表单展开状态
/// </summary>
public enum FormExpandState
{
	/// <summary>
	///		折叠
	/// </summary>
	Collapse,

	/// <summary>
	///		展开
	/// </summary>
	Expand,
}
