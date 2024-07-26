using System.Threading.Tasks;

namespace Test.Pages;

public partial class TestPage
{
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		//ProcessWindow window = new();
		//window.Show();
		DialogWindow dialog = new();
		dialog.Show();
	}
}
