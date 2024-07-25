﻿using Microsoft.AspNetCore.Components;

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
			string uri = Nav.ToAbsoluteUri(Href).ToString();
			if (!uri.EndsWith('/'))
			{
				uri += "/";
			}

			return uri;
		}
	}

	private string AbsoluteCurrentUri
	{
		get
		{
			string uri = Nav.Uri;
			if (!uri.EndsWith('/'))
			{
				uri += "/";
			}

			return uri;
		}
	}

	/// <summary>
	///		只要 CurrentRelativeUri 是 RelativeHrefUri 的子路径就应该聚焦。
	/// </summary>
	private bool ShouldFocus
	{
		get
		{
			Uri href_uri = new(AbsoluteHrefUri);
			Uri current_uri = new(AbsoluteCurrentUri);
			return href_uri.IsBaseOf(current_uri);
		}
	}
}
