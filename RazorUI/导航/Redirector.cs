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

	/// <summary>
	///		将当前路径的父级路径的重定向目标路径更新为当前路径。
	/// </summary>
	public void UpdateRedirectUri()
	{
		string current_relative_path = Nav.ToBaseRelativePath(uri: Nav.Uri);
		if (current_relative_path == string.Empty)
		{
			// 当前是根路径，直接返回
			return;
		}

		int index = current_relative_path.IndexOf('/');
		if (index == -1)
		{
			// 当前是一级路径，将根路径的重定向目标设置为本路径
			RedirectUriProvider.SetRedirectUri(string.Empty, Nav.Uri);
			return;
		}

		// 将上级相对路径的重定向目标设置为本路径
		string parent_path = current_relative_path[..index];
		RedirectUriProvider.SetRedirectUri(parent_path, Nav.Uri);
	}
}
