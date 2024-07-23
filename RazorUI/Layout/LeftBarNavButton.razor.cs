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
	/// </summary>
	private bool ShouldFocus
	{
		get
		{
			if (!CurrentRelativeUri.StartsWith(RelativeHrefUri))
			{
				return false;
			}

			if (RelativeHrefUri == CurrentRelativeUri)
			{
				return true;
			}

			// 现在是 CurrentRelativeUri 比 RelativeHrefUri 长
			if (CurrentRelativeUri[RelativeHrefUri.Length] != '/')
			{
				/* 只有 CurrentRelativeUri 比 RelativeHrefUri 多出的部分是以路径分隔符开头，
				 * 才能说明 CurrentRelativeUri 是 RelativeHrefUri 的子路径
				 */
				return false;
			}

			return true;
		}
	}
}
