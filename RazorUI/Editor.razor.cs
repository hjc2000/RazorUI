using JSInteropLib;
using Microsoft.AspNetCore.Components;

namespace RazorUI;

public partial class Editor
{
	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		await base.OnAfterRenderAsync(firstRender);
		_jsm = new JSModule(JS, "./_content/RazorUI/Editor.razor.js");
		_jsop = new JSOp(JS);
		_init_tcs.TrySetResult();

		await _jsop.AddScriptAsync("./_content/RazorUI/monaco-editor.min.js");
		await _jsop.AddCssAsync("./_content/RazorUI/monaco-editor.min.css");
	}

	private TaskCompletionSource _init_tcs = new();
	private JSModule _jsm = default!;
	private JSOp _jsop = default!;
	private ElementReference _editor_container_element;
}
