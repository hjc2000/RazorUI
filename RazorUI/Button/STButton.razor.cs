using Microsoft.AspNetCore.Components;

namespace RazorUI.Button;
public partial class STButton
{
	[Parameter]
	public RenderFragment? ChildContent { get; set; }
	[Parameter]
	public bool Disabled { get; set; } = false;

	[Parameter(CaptureUnmatchedValues = true)]
	public Dictionary<string, object>? CaptureUnmatchedValues { get; set; }
}
