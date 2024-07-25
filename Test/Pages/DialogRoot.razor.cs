using System.Threading.Tasks;

namespace Test.Pages;

public partial class DialogRoot
{
	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		await base.OnAfterRenderAsync(firstRender);
		if (firstRender)
		{
			_init_tcs.TrySetResult();
		}
	}

	private TaskCompletionSource _init_tcs = new();
}
