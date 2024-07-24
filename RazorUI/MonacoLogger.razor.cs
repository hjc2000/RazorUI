
namespace RazorUI;

public partial class MonacoLogger : IAsyncDisposable
{
	protected override void OnInitialized()
	{
		base.OnInitialized();
		Writer.WriteEvent += StateHasChanged;
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

		Writer.WriteEvent -= StateHasChanged;
	}
}
