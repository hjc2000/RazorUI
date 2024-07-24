
using BlazorMonaco.Editor;
using JCNET.定时器;

namespace RazorUI;

public partial class MonacoLogger : IAsyncDisposable
{
	/// <summary>
	///		初始化。
	/// </summary>
	/// <returns></returns>
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		TaskTimer.SetInterval(async () =>
		{
			await _editor_init_tcs.Task;
			Console.WriteLine("666666666666666");
			Console.WriteLine("666666666666666");
			Console.WriteLine("666666666666666");
			TextModel module = await Editor.GetModel();
			await module.SetValue(Writer.ToString());
		}, 1000, CancellationToken.None);
	}

	private bool _disposed = false;

	/// <summary>
	///		释放。
	/// </summary>
	/// <returns></returns>
	public async ValueTask DisposeAsync()
	{
		if (_disposed)
		{
			return;
		}

		_disposed = true;
		GC.SuppressFinalize(this);
		await ValueTask.CompletedTask;

	}

	private TaskCompletionSource _editor_init_tcs = new();
	private StandaloneCodeEditor _editor = default!;

	private StandaloneCodeEditor Editor
	{
		get
		{
			return _editor;
		}
		set
		{
			if (value is not null)
			{
				_editor = value;
				_editor_init_tcs.TrySetResult();
			}
		}
	}

	private IDStringProvider _id_provider = new();

	private StandaloneEditorConstructionOptions EditorConstructionOptions(StandaloneCodeEditor editor)
	{
		return new StandaloneEditorConstructionOptions
		{
			AutomaticLayout = true,
			Language = "javascript",
			Theme = "vs-dark",
			Value = string.Empty,
			ReadOnly = true,
		};
	}
}
