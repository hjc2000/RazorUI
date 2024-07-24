using Microsoft.AspNetCore.Components;

namespace RazorUI.Layout;

/// <summary>
///		用来放置到 LeftBarNav 中的导航按钮。
/// </summary>
public partial class LeftBarNavButton
{
	/// <summary>
	///		子内容。可以放置按钮图标。
	/// </summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	/// <summary>
	///		左边框的颜色。<br/>
	///		左边框只有本按钮聚焦是才会显示。<br/>
	///		聚焦的条件是：导航系统的当前导航到的路径等于 Href 及其子路径。<br/>
	/// </summary>
	[Parameter]
	public string LeftBorderColor { get; set; } = "yellow";

	/// <summary>
	///		本按钮绑定的路径。<br/>
	///		点击后会导航到这个路径。<br/>
	///		当导航系统的当前路径等于本属性指示的路径，或位于本属性指示的路径的子路径时，本按钮会聚焦。<br/>
	/// </summary>
	[Parameter]
	public string Href { get; set; } = "./";

	/// <summary>
	///		Href 转化为的绝对路径
	/// </summary>
	private string AbsoluteHrefUri
	{
		get
		{
			return Nav.ToAbsoluteUri(Href).ToString();
		}
	}

	/// <summary>
	///		Href 转化为的相对于 base 标签中指定的基路径的相对路径。
	/// </summary>
	private string RelativeHrefUri
	{
		get
		{
			return Nav.ToBaseRelativePath(AbsoluteHrefUri);
		}
	}

	/// <summary>
	///		导航系统当前所处的绝对 URI 相对于基础 URI 的相对 URI。
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
