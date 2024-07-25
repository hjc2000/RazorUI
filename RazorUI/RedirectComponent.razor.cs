using Microsoft.AspNetCore.Components;

namespace RazorUI;

public partial class RedirectComponent
{
	/// <summary>
	///		初始化时会将路由系统重定向到指定路径。
	/// </summary>
	protected override void OnInitialized()
	{
		base.OnInitialized();
		Nav.NavigateTo(Nav.ToAbsoluteUri(Href).ToString());
	}

	/// <summary>
	///		要重定向到的路径。
	///		这里是相对于基路径的相对路径。
	/// </summary>
	[Parameter]
	public string Href { get; set; } = string.Empty;
}
