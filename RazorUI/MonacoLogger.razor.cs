
using JCNET.定时器;

namespace RazorUI;

public partial class MonacoLogger : IAsyncDisposable
{
	protected override void OnInitialized()
	{
		base.OnInitialized();
		TaskTimer.SetInterval(async () =>
		{
			await Task.CompletedTask;
			Console.WriteLine("666666666666666");
			Console.WriteLine("666666666666666");
			Console.WriteLine("666666666666666");
			Content = Writer.ToString();
			await InvokeAsync(StateHasChanged);
		}, 1000, CancellationToken.None);
	}

	private bool _disposed = false;
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

	private string Content { get; set; } = string.Empty;
}
