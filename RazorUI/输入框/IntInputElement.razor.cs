using JCNET.数学;
using Microsoft.AspNetCore.Components;

namespace RazorUI.输入框;

/// <summary>
///		整型值输入框。
/// </summary>
public partial class IntInputElement
{
	/// <summary>
	///		将选择框设为只读。
	/// </summary>
	[Parameter]
	public bool ReadOnly { get; set; }

	/// <summary>
	///		绑定的值
	/// </summary>
	[Parameter]
	public int Value { get; set; }

	/// <summary>
	///		绑定的值
	/// </summary>
	[Parameter]
	public EventCallback<int> ValueChanged { get; set; }

	/// <summary>
	///		允许的范围。
	/// </summary>
	[Parameter]
	public NumberRange<int>? Range { get; set; }

	private string ValueString
	{
		get
		{
			return Value.ToString();
		}
	}

	private async Task OnChange(string value)
	{
		bool result = int.TryParse(value, out int out_long);
		if (!result)
		{
			return;
		}

		if (Range is null)
		{
			await ValueChanged.InvokeAsync(out_long);
			return;
		}

		if (Range.InRange(out_long))
		{
			await ValueChanged.InvokeAsync(out_long);
		}
	}
}
