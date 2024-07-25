
using BlazorMonaco.Editor;
using JCNET.定时器;
using Microsoft.AspNetCore.Components;

namespace RazorUI;

/// <summary>
///		利用 monaco 编辑器进行日志输出。
/// </summary>
public partial class MonacoLogger : IAsyncDisposable
{
	/// <summary>
	///		构造函数
	/// </summary>
	public MonacoLogger()
	{
		// 拼接 id 选择器
		CssString = $"#{_id_provider.IdString}" + @"
			{
				width: 100%;
				height: 100%;
				box-sizing: border-box;
				margin: 0;
				padding: 20px 0 0 0;
			}
			";
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

		_cancel_refresh.Cancel();
	}

	/// <summary>
	///		自动滚动编辑器。
	/// </summary>
	[Parameter]
	public bool AutoScroll { get; set; } = true;

	private CancellationTokenSource _cancel_refresh = new();
	private StandaloneCodeEditor _editor = default!;
	private bool _edit_init_completed = false;

	private string CssString { get; }

	private IDStringProvider _id_provider = new();

	private async Task OnMonacoEditInit()
	{
		if (_edit_init_completed)
		{
			return;
		}

		_edit_init_completed = true;
		await Task.CompletedTask;

		async Task refresh_func()
		{
			try
			{
				await _editor.SetValue(Writer.ToString());
				if (AutoScroll)
				{
					int top = (int)await _editor.GetScrollHeight();
					if (top > 0)
					{
						await _editor.SetScrollTop(top, ScrollType.Immediate);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		TaskTimer.SetInterval(refresh_func,
			1000,
			_cancel_refresh.Token);
	}

	private StandaloneEditorConstructionOptions EditorConstructionOptions(StandaloneCodeEditor editor)
	{
		return new StandaloneEditorConstructionOptions
		{
			AutomaticLayout = true,
			Language = "csharp",
			Theme = "vs-dark",
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
