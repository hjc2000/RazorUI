using Microsoft.AspNetCore.Components;

namespace RazorUI.Button;

/// <summary>
///		开关按钮
/// </summary>
public partial class SwitchButton
{
	/// <summary>
	///		开关状态
	/// </summary>
	[Parameter]
	public SwitchButtonState State { get; set; }

	/// <summary>
	///		开关状态改变后的回调
	/// </summary>
	[Parameter]
	public EventCallback<SwitchButtonState> StateChanged { get; set; }

	/// <summary>
	///		在捕获 Parameter 的最后，捕获所有之前未捕获的 html 标签属性。
	/// </summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public Dictionary<string, object>? CaptureUnmatchedValues { get; set; }

	private async Task OnClickAsync()
	{
		if (State == SwitchButtonState.On)
		{
			State = SwitchButtonState.Off;
			await StateChanged.InvokeAsync(SwitchButtonState.Off);
		}
		else
		{
			State = SwitchButtonState.On;
			await StateChanged.InvokeAsync(SwitchButtonState.On);
		}
	}
}

/// <summary>
///		开关按钮的状态
/// </summary>
public enum SwitchButtonState
{
	/// <summary>
	///		关
	/// </summary>
	Off,

	/// <summary>
	///		开
	/// </summary>
	On,
}
