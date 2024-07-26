using Microsoft.AspNetCore.Components;

namespace RazorUI.导航;

/// <summary>
///		重定向器
/// </summary>
public class Redirector
{
	/// <summary>
	///		构造函数
	/// </summary>
	/// <param name="nav"></param>
	/// <param name="provider"></param>
	public Redirector(NavigationManager nav, IRedirectUriProvider provider)
	{
		Nav = nav;
		RedirectUriProvider = provider;
	}

	private NavigationManager Nav { get; }
	private IRedirectUriProvider RedirectUriProvider { get; }

	/// <summary>
	///		进行重定向
	/// </summary>
	public void Redirect()
	{
		try
		{
			string current_relative_path = Nav.ToBaseRelativePath(uri: Nav.Uri);
			string dst_path = RedirectUriProvider.GetRedirectUri(current_relative_path);
			Nav.NavigateTo(dst_path);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}
	}
}
