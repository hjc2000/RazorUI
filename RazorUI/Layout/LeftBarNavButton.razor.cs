using Microsoft.AspNetCore.Components;

namespace RazorUI.Layout;

public partial class LeftBarNavButton
{
	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	[Parameter]
	public string LeftBorderColor { get; set; } = "yellow";

	[Parameter]
	public string Href { get; set; } = "./";

	private bool ShouldFocus
	{
		get
		{
			string uri = Nav.ToAbsoluteUri(Href).ToString();
			return uri == Nav.Uri;
		}
	}
}
