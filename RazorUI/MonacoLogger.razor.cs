
using BlazorMonaco.Editor;
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
		CssString = $"#{_id_provider.IdString}" +
			@"{
				width: 100%;
				height: 100%;
				box-sizing: border-box;
				margin: 0;
				padding: 20px 0 0 0;
			}";
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

	/// <summary>
	///		是否将编辑器设为只读。
	/// </summary>
	[Parameter]
	public bool ReadOnly { get; set; } = false;

	/// <summary>
	///		字体大小。
	/// </summary>
	[Parameter]
	public int FontSize { get; set; } = 20;

	/// <summary>
	///		是否开启自动换行。设置为 true 开启，为 false 关闭。
	///		默认值：true
	/// </summary>
	[Parameter]
	public bool AutoWordWrap { get; set; } = true;

	private CancellationTokenSource _cancel_refresh = new();
	private StandaloneCodeEditor _editor = default!;

	private string CssString { get; }

	private IDStringProvider _id_provider = new();

	private async Task OnMonacoEditInit()
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

	private StandaloneEditorConstructionOptions EditorConstructionOptions(StandaloneCodeEditor editor)
	{
		return new StandaloneEditorConstructionOptions
		{
			AutomaticLayout = true,
			Language = "csharp",
			Theme = "vs-dark",
			ReadOnly = ReadOnly,
			ScrollBeyondLastLine = false,
			LineHeight = (int)(FontSize * 1.5),
			FontSize = FontSize,
			WordWrap = AutoWordWrap ? "wordWrapColumn" : "off",
			Padding = new EditorPaddingOptions()
			{
				Top = 20,
				Bottom = 20,
			},
		};
	}
}
