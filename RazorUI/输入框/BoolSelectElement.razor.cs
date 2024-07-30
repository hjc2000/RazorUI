using Microsoft.AspNetCore.Components;

namespace RazorUI.输入框;

/// <summary>
///		布尔选择框。
/// </summary>
public partial class BoolSelectElement
{
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
}
