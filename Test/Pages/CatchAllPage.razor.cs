using Microsoft.AspNetCore.Components;
using RazorUI.导航;
using System;
using System.Threading.Tasks;

namespace Test.Pages;

public partial class CatchAllPage
{
	protected override async Task OnParametersSetAsync()
	{
		await base.OnParametersSetAsync();
		Console.WriteLine($"CatchAllPage 将 {Nav.Uri} 捕获到 {nameof(Path)}，{nameof(Path)} = {Path}");
		Redirector.Redirect();
	}

	[Parameter]
	public string Path { get; set; } = string.Empty;

	[Inject]
	private NavigationManager Nav { get; set; } = default!;

	[Inject]
	private Redirector Redirector { get; set; } = default!;
}
