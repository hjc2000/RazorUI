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

	private string AbsoluteHrefUri
	{
		get
		{
			return Nav.ToAbsoluteUri(Href).ToString();
		}
	}

	private string RelativeHrefUri
	{
		get
		{
			return Nav.ToBaseRelativePath(AbsoluteHrefUri);
		}
	}

	/// <summary>
	///		导航系统当前所处的绝对 URI 相对于基础 URI 的 URI。
	/// </summary>
	private string CurrentRelativeUri
	{
		get
		{
			return Nav.ToBaseRelativePath(Nav.Uri);
		}
	}

	/// <summary>
	///		只要 CurrentRelativeUri 是 RelativeHrefUri 的子路径就应该聚焦。
	///		因为左边按钮条是用来做一级导航的，左边菜单做二级导航。
	/// </summary>
	private bool ShouldFocus
	{
		get
		{
			string current_relative_uri = CurrentRelativeUri;
			string relative_href_uri = RelativeHrefUri;

			if (!current_relative_uri.StartsWith(relative_href_uri))
			{
				return false;
			}

			if (relative_href_uri == current_relative_uri)
			{
				return true;
			}

			// 现在是 current_relative_uri 比 relative_href_uri 长
			if (current_relative_uri[relative_href_uri.Length] != '/')
			{
				/* 只有 current_relative_uri 比 relative_href_uri 多出的部分是以路径分隔符开头，
				 * 才能说明 current_relative_uri 是 relative_href_uri 的子路径
				 */
				return false;
			}

			return true;
		}
	}
}
