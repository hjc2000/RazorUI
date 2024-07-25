
namespace RazorUI.导航;

/// <summary>
///		重定向组件。
/// </summary>
public partial class RedirectComponent
{
	/// <summary>
	///		初始化。会进行重定向。
	/// </summary>
	/// <returns></returns>
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		string current_relative_path = Nav.ToBaseRelativePath(Nav.Uri);
		string dst_path = RedirectUriProvider.GetRedirectUri(current_relative_path);
		Nav.NavigateTo(dst_path);
	}
}
