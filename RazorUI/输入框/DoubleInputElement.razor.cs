using JCNET.数学;
using Microsoft.AspNetCore.Components;

namespace RazorUI.输入框;

/// <summary>
///		浮点数输入框
/// </summary>
public partial class DoubleInputElement
{
	private IDStringProvider _data_list_id_string_provider = new();

	/// <summary>
	///		将选择框设为只读。
	/// </summary>
	[Parameter]
	public bool ReadOnly { get; set; }

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

	/// <summary>
	///		当前填写的内容的错误状态。
	/// </summary>
	[Parameter]
	public InputElementErrorState ErrorState { get; set; } = InputElementErrorState.Unknow;

	/// <summary>
	///		当前填写的有错误时将鼠标放到输入框上时显示的消息。
	/// </summary>
	[Parameter]
	public string ErrorMessage { get; set; } = string.Empty;

	/// <summary>
	///		数据列表
	/// </summary>
	[Parameter]
	public IEnumerable<double>? DataList { get; set; }
}
