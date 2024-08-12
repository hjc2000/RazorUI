using JSInteropLib;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RazorUI.Echarts;

public partial class BarChart :
	IJSObjectProjection,
	IAsyncDisposable
{
	private bool _disposed = false;

	/// <inheritdoc/>
	public async ValueTask DisposeAsync()
	{
		if (_disposed)
		{
			return;
		}

		_disposed = true;
		GC.SuppressFinalize(this);

		if (Projection is not null)
		{
			await Projection.InvokeVoidAsync("Dispose");
			Console.WriteLine("释放 js 的 BarChart 对象");
			await Projection.DisposeAsync();
		}

		if (_jsop is not null)
		{
			await _jsop.DisposeAsync();
		}

		if (_jsm is not null)
		{
			await _jsm.DisposeAsync();
		}
	}

	/// <inheritdoc/>
	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		await base.OnAfterRenderAsync(firstRender);
		if (!firstRender)
		{
			return;
		}

		_jsop = new JSOp(JS);
		await _jsop.AddScriptAsync("./_content/RazorUI/echarts.min.js");
		_jsm = new JSModule(JS, "./_content/RazorUI/Echarts/BarChart.razor.js");
		Projection = await _jsm.InvokeAsync<IJSObjectReference>("BarChart.Create", _chart_container);
		await Projection.InvokeVoidAsync("Draw");
	}

	[Inject]
	private IJSRuntime JS { get; set; } = default!;

	private ElementReference _chart_container;
	private JSOp _jsop = default!;
	private JSModule _jsm = default!;

	/// <summary>
	///		js 侧的镜像
	/// </summary>
	public IJSObjectReference Projection { get; private set; } = default!;

}
