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
