using JCNET.数学;
using Microsoft.AspNetCore.Components;

namespace RazorUI.输入框;

/// <summary>
///		整型值输入框。
/// </summary>
public partial class IntInputElement
{
	/// <summary>
	///		绑定的值
	/// </summary>
	[Parameter]
	public long Value { get; set; }

	/// <summary>
	///		绑定的值
	/// </summary>
	[Parameter]
	public EventCallback<long> ValueChanged { get; set; }

	/// <summary>
	///		允许的范围。
	/// </summary>
	[Parameter]
	public NumberRange<long>? Range { get; set; }

	private string ValueString
	{
		get
		{
			return Value.ToString();
		}
	}

	private async Task OnChange(string value)
	{
		bool result = long.TryParse(value, out long out_long);
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
