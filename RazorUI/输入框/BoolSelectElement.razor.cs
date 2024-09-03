using Microsoft.AspNetCore.Components;

namespace RazorUI.输入框;

/// <summary>
///		布尔选择框。
/// </summary>
public partial class BoolSelectElement
{
	/// <summary>
	///		将选择框设为只读。
	/// </summary>
	[Parameter]
	public bool ReadOnly { get; set; }

	/// <summary>
	///		绑定值。
	/// </summary>
	[Parameter]
	public bool Value { get; set; }

	/// <summary>
	///		绑定值。
	/// </summary>
	[Parameter]
	public EventCallback<bool> ValueChanged { get; set; }

	private int BoolInt
	{
		get
		{
			return Value ? 1 : 0;
		}
	}

	private async Task OnChange(int value)
	{
		if (ReadOnly)
		{
			return;
		}

		await ValueChanged.InvokeAsync(value != 0);
	}

	/// <summary>
	///		true 显示在下拉列表中的值。
	/// </summary>
	[Parameter]
	public string TrueText { get; set; } = "true";

	/// <summary>
	///		false 显示在下拉列表中的值。
	/// </summary>
	[Parameter]
	public string FalseText { get; set; } = "false";

	/// <summary>
	///		当前填写的有错误。
	/// </summary>
	[Parameter]
	public bool IsError { get; set; } = false;

	/// <summary>
	///		当前填写的有错误时将鼠标放到输入框上时显示的消息。
	/// </summary>
	[Parameter]
	public string ErrorMessage { get; set; } = string.Empty;
}
