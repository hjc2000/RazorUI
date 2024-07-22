using Microsoft.AspNetCore.Components;

namespace RazorUI.Layout;

public partial class LeftBarNavButton
{
	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	[Parameter]
	public string LeftBorderColor { get; set; } = "yellow";

	/// <summary>
	///		设置本按钮所对应的路径。
	/// </summary>
	[Parameter]
	public string Path { get; set; } = "./";

	private bool IsCurrentPath
	{
		get
		{
			UriBuilder builder = new(Nav.Uri);
			string relative_path = System.IO.Path.GetRelativePath("/", builder.Path);
			string current_path = System.IO.Path.GetRelativePath("./", Path);
			if (current_path == relative_path)
			{
				return true;
			}

			return false;
		}
	}
}
