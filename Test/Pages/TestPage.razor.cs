using System;
using System.Threading.Tasks;

namespace Test.Pages;

public partial class TestPage
{
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		//ProcessWindow window = new();
		//window.Show();
	}

	private async Task OnClick()
	{
		await Task.CompletedTask;
		Console.WriteLine("666666666666666");
		Console.WriteLine("666666666666666");
		Console.WriteLine("666666666666666");
		Writer.Flush();
	}
}
