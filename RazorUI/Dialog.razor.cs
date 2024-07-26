using JSInteropLib;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RazorUI;

/// <summary>
///		封装 html 的对话框
/// </summary>
public partial class Dialog
	: IJSObjectProjection, IAsyncDisposable
{
	/// <summary>
	///		构造函数
	/// </summary>
	public Dialog()
	{
		_close_callback_helper.CallbackAction = async () =>
		{
			Console.WriteLine("弹窗关闭");
			await DialogClosedEvent.InvokeAsync();
		};
	}

	/// <summary>
	///		因为要包装 dialog 标签，所以要获取到 dialog 标签的引用，所以要等到渲染完成后
	///		才能执行初始化工作。
	/// </summary>
	/// <param name="firstRender"></param>
	/// <returns></returns>
	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		await base.OnAfterRenderAsync(firstRender);
		if (!firstRender)
		{
			return;
		}

		_jsm = new JSModule(_jsrt, "./_content/RazorUI/Dialog.razor.js");

		Projection = await _jsm.InvokeAsync<IJSObjectReference>("DialogWrapper.create",
			 _dialog_element,
			 _close_callback_helper.DotNetHelper);

		_init_tcs.TrySetResult();
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

		await _jsm.DisposeAsync();
		await Projection.DisposeAsync();
		await _close_callback_helper.DisposeAsync();
	}

	private JSModule _jsm = default!;

	/// <inheritdoc/>
	public IJSObjectReference Projection { get; set; } = default!;
	private TaskCompletionSource _init_tcs = new();
	private ElementReference _dialog_element;
	private CallbackHelper _close_callback_helper = new();

	/// <summary>
	///		对话框关闭后会触发此事件
	/// </summary>
	[Parameter]
	public EventCallback DialogClosedEvent { get; set; }

	/// <summary>
	///		对话框的子内容。
	/// </summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	/// <summary>
	///		以非模态形式显示对话框
	/// </summary>
	/// <returns></returns>
	public async Task ShowAsync()
	{
		await _init_tcs.Task;
		await Projection.InvokeVoidAsync("show");
	}

	/// <summary>
	///		以模态形式显示对话框
	/// </summary>
	/// <returns></returns>
	public async Task ShowModalAsync()
	{
		await _init_tcs.Task;
		await Projection.InvokeVoidAsync("showModal");
	}

	/// <summary>
	///		关闭对话框
	/// </summary>
	/// <returns></returns>
	public async Task CloseAsync()
	{
		await _init_tcs.Task;
		await Projection.InvokeVoidAsync("close");
	}

	/// <summary>
	///		查询当前对话框是否开启。不管是模态的还是非模态的。
	/// </summary>
	/// <returns></returns>
	public async Task<bool> IsOpened()
	{
		await _init_tcs.Task;
		return await Projection.InvokeAsync<bool>("isOpened");
	}

	/// <summary>
	///		捕获所有遗漏的 html 标签属性。
	/// </summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public Dictionary<string, object>? Attributes { get; set; }
}
