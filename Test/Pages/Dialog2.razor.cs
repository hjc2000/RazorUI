using Microsoft.AspNetCore.Components;
using RazorUI.导航;
using System.Threading.Tasks;

namespace Test.Pages;

public partial class Dialog2
{
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		Redirector.UpdateRedirectUri();
	}

	[Inject]
	private Redirector Redirector { get; set; } = default!;
}
