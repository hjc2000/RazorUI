using JSInteropLib;

namespace BlazorApp1.Pages;

public partial class TestPage
{
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		_jsop = new JSOp(JS);
		_init_tcs.TrySetResult();

		//await _jsop.AddScriptAsync("_content/BlazorMonaco/jsInterop.js");
		//await _jsop.AddScriptAsync("_content/BlazorMonaco/lib/monaco-editor/min/vs/loader.js");
		//await _jsop.AddScriptAsync("_content/BlazorMonaco/lib/monaco-editor/min/vs/editor/editor.main.js");

	}

	private TaskCompletionSource _init_tcs = new();
	private JSOp _jsop = default!;
}
