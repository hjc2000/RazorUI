using JSInteropLib;
using Microsoft.AspNetCore.Components;

namespace RazorUI.ImportHelper;

/// <summary>
///		帮助导入 MonacoBlazor 编辑器的环境。例如添加必要的 js 文件到 script 标签中。
///		将 MonacoBlazor 的组件标签放到本组件的标签中，就可以保证在环境加载好后才开始
///		加载 MonacoBlazor，这样就不会抛异常。
/// </summary>
public partial class MonacoImportHelper
{
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		_jsop = new JSOp(JS);
		await _jsop.AddScriptAsync("./_content/BlazorMonaco/jsInterop.js");
		await _jsop.AddScriptAsync("./_content/BlazorMonaco/lib/monaco-editor/min/vs/loader.js");
		await _jsop.AddScriptAsync("./_content/BlazorMonaco/lib/monaco-editor/min/vs/editor/editor.main.js");
		await _jsop.AddStyleAsync(CssString);
		_init_tcs.TrySetResult();
	}

	private TaskCompletionSource _init_tcs = new();
	private JSOp _jsop = default!;

	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	[Parameter]
	public string Width { get; set; } = "100%";
	[Parameter]
	public string Height { get; set; } = "100%";

	/// <summary>
	///		传进来 css 字符串。将会被添加到 style 标签然后将此 style 标签放到 head 标签中。
	///		本属性的默认 css 字符串提供了以下类选择器：
	///			<br/> .full-box
	///			<br/> .padding_top_10px
	///			<br/> .padding_top_20px
	/// </summary>
	[Parameter]
	public string CssString { get; set; } = @"
		.full-box {
			width: 100%;
			height: 100%;
			box-sizing: border-box;
			margin: 0;
		}

		.padding_top_10px {
			padding-top: 10px;
		}

		.padding_top_20px {
			padding-top: 20px;
		}

		";
}
