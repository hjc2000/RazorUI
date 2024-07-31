﻿using JCNET.反射;
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
		OptionDictionary = EnumReflex.ToDictionary<TEnum>();
	}

	private static Dictionary<TEnum, string> OptionDictionary { get; }

	/// <summary>
	///		将选择框设为只读。
	/// </summary>
	[Parameter]
	public bool ReadOnly { get; set; }

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
		if (ReadOnly)
		{
			return;
		}

		await ValueChanged.InvokeAsync(value);
	}
}
