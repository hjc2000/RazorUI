using Microsoft.AspNetCore.Components;

namespace RazorUI.输入框;

/// <summary>
///		枚举值下拉选择框。
/// </summary>
/// <typeparam name="TEnum"></typeparam>
public partial class EnumSelectElement<TEnum> where TEnum : Enum
{
	static EnumSelectElement()
	{
		OptionDictionary = EnumTypeToDictionary();
	}

	private static Dictionary<TEnum, string> OptionDictionary { get; }

	/// <summary>
	///		绑定值。
	/// </summary>
	[Parameter]
	public TEnum Value { get; set; } = default!;

	/// <summary>
	///		绑定值。
	/// </summary>
	[Parameter]
	public EventCallback<TEnum> ValueChanged { get; set; }

	private async Task OnOptionChanged(TEnum value)
	{
		await ValueChanged.InvokeAsync(value);
	}

	private static Dictionary<TEnum, string> EnumTypeToDictionary()
	{
		Dictionary<TEnum, string> values = Enum.GetValues(typeof(TEnum))
						 .Cast<TEnum>()
						 .ToDictionary(
							 (TEnum e) =>
							 {
								 return e;
							 },
							 (TEnum e) =>
							 {
								 return e.ToString();
							 }
						 );

		return values;
	}
}
