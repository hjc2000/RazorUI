
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
			try
			{
				await _editor_init_tcs.Task;
				Console.WriteLine("666666666666666");
				Console.WriteLine("666666666666666");
				Console.WriteLine("666666666666666");
				await _editor.SetValue(Writer.ToString());
				int top = (int)await _editor.GetScrollHeight();
				if (top > 0)
				{
					await _editor.SetScrollTop(top, ScrollType.Immediate);
				}
			}
			catch (Exception ex)
			{
			}
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

	private IDStringProvider _id_provider = new();

	private async Task OnMonacoEditInit()
	{
		await Task.CompletedTask;
		_editor_init_tcs.TrySetResult();
	}

	private StandaloneEditorConstructionOptions EditorConstructionOptions(StandaloneCodeEditor editor)
	{
		return new StandaloneEditorConstructionOptions
		{
			AutomaticLayout = true,
			Language = "javascript",
			Theme = "vs-dark",
			Value = string.Empty,
			ReadOnly = true,
			ScrollBeyondLastLine = false,
			Padding = new EditorPaddingOptions()
			{
				Top = 20,
				Bottom = 20,
			},
		};
	}
}
