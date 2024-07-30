using System.Threading.Tasks;

namespace Test.Pages;

public partial class TestPage
{
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		//ProcessWindow window = new();
		//window.Show();
		//DialogWindow dialog = new();
		//dialog.Show();
	}

	private static bool _value = false;

	private bool Value
	{
		get
		{
			return _value;
		}
		set
		{
			_value = value;
		}
	}
}
