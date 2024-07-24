using Microsoft.AspNetCore.Components;

namespace RazorUI.输入框;

public partial class EnumSelectElement<TEnum> where TEnum : Enum
{
	static EnumSelectElement()
	{
		OptionDictionary = EnumTypeToDictionary();
	}

	private static Dictionary<TEnum, string> OptionDictionary { get; }

	/// <summary>
	///		绑定选项的键。
	/// </summary>
	[Parameter]
	public TEnum OptionKey { get; set; }

	/// <summary>
	///		绑定选项的键。
	/// </summary>
	[Parameter]
	public EventCallback<TEnum> OptionKeyChanged { get; set; }

	private async Task OnOptionChanged(TEnum value)
	{
		await OptionKeyChanged.InvokeAsync(value);
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
