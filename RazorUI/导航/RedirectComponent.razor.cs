
namespace RazorUI.导航;

/// <summary>
///		重定向组件。
/// </summary>
public partial class RedirectComponent
{
	/// <inheritdoc/>
	protected override async Task OnParametersSetAsync()
	{
		await base.OnParametersSetAsync();
		string current_relative_path = Nav.ToBaseRelativePath(Nav.Uri);
		string dst_path = RedirectUriProvider.GetRedirectUri(current_relative_path);
		Nav.NavigateTo(dst_path);
	}
}
