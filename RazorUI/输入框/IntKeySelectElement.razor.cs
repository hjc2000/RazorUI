using Microsoft.AspNetCore.Components;

namespace RazorUI.输入框;

public partial class IntKeySelectElement
{
	/// <summary>
	///		枚举类的每一个值强制转换为 int 后作为键，每个枚举值的名称作为值的字典。
	/// </summary>
	[Parameter]
	public Dictionary<int, string> OptionDictionary { get; set; } = [];

	/// <summary>
	///		绑定选项的键。
	/// </summary>
	[Parameter]
	public int OptionKey { get; set; }

	/// <summary>
	///		绑定选项的键。
	/// </summary>
	[Parameter]
	public EventCallback<int> OptionKeyChanged { get; set; }

	private async Task OnOptionChanged(int value)
	{
		await OptionKeyChanged.InvokeAsync(value);
	}
}
