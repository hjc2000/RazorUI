using BlazorMonaco.Editor;
using JSInteropLib;
using System;
using System.Threading.Tasks;

namespace Test.Pages;

public partial class TestPage
{
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		_jsop = new JSOp(JS);
		_init_tcs.TrySetResult();

		//ProcessWindow window = new();
		//window.Show();
	}

	private TaskCompletionSource _init_tcs = new();
	private JSOp _jsop = default!;

	private string _css_string = @"
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

	private string? _guid = null;
	private string Id
	{
		get
		{
			_guid ??= Guid.NewGuid().ToString();
			return _guid;
		}
	}

	private StandaloneEditorConstructionOptions EditorConstructionOptions(StandaloneCodeEditor editor)
	{
		return new StandaloneEditorConstructionOptions
		{
			AutomaticLayout = true,
			Language = "javascript",
			Theme = "vs-dark",
			Value = "",
		};
	}
}
