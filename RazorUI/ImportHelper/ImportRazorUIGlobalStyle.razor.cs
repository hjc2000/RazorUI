using JSInteropLib;

namespace RazorUI.ImportHelper;

public partial class ImportRazorUIGlobalStyle
{
	/// <summary>
	///		初始化。
	///		会添加 RazorUIGlobalStyle.css 到 head 标签中。
	/// </summary>
	/// <returns></returns>
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		_jsop = new JSOp(JSRuntime);
		_init_tcs.TrySetResult();
		await _jsop.AddCssAsync("./_content/RazorUI/RazorUIGlobalStyle.css");
	}

	private TaskCompletionSource _init_tcs = new();
	private JSOp _jsop = default!;
}
