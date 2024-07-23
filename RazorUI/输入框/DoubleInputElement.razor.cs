using JCNET.数学;
using Microsoft.AspNetCore.Components;

namespace RazorUI.输入框;

public partial class DoubleInputElement
{
	/// <summary>
	///		绑定的值
	/// </summary>
	[Parameter]
	public double Value { get; set; }

	/// <summary>
	///		绑定的值
	/// </summary>
	[Parameter]
	public EventCallback<double> ValueChanged { get; set; }

	/// <summary>
	///		允许的范围。
	/// </summary>
	[Parameter]
	public NumberRange<double>? Range { get; set; }

	private string ValueString
	{
		get
		{
			return Value.ToString();
		}
	}

	private async Task OnChange(string value)
	{
		bool result = double.TryParse(value, out double out_long);
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
