
namespace RazorUI.导航;

/// <summary>
///		重定向组件。
/// </summary>
public partial class RedirectComponent
{
	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		string current_relative_path = Nav.ToBaseRelativePath(Nav.Uri);
		string dst_relative_path = RedirectUriProvider.GetRedirectUri(current_relative_path);
		Nav.NavigateTo(dst_relative_path);
	}
}
