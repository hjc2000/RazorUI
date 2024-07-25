using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace RazorUI.Layout;

/// <summary>
///		二级导航菜单。
/// </summary>
public partial class SecondaryNavMenu
{
	private bool _disposed = false;

	/// <summary>
	///		释放。
	/// </summary>
	/// <returns></returns>
	public async ValueTask DisposeAsync()
	{
		if (_disposed)
		{
			return;
		}

		_disposed = true;
		GC.SuppressFinalize(this);
		await ValueTask.CompletedTask;

		Nav.LocationChanged -= OnLocationChange;
	}

	/// <summary>
	///		初始化。
	/// </summary>
	protected override void OnInitialized()
	{
		base.OnInitialized();
		Nav.LocationChanged += OnLocationChange;
	}

	private void OnLocationChange(object? sender, LocationChangedEventArgs args)
	{
		StateHasChanged();
	}

	/// <summary>
	///		子内容
	/// </summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	/// <summary>
	///		内边距。默认：10px
	/// </summary>
	[Parameter]
	public string Padding { get; set; } = "10px";

	/// <summary>
	///		网格行间隙。默认：10px
	/// </summary>
	[Parameter]
	public string GridRowGap { get; set; } = "10px";

	/// <summary>
	///		一级导航路径。
	///		只有当前路径的一级路径与本属性匹配时，本二级导航菜单才会显示。
	/// </summary>
	[Parameter]
	public string FirstLevelNavigationPath { get; set; } = string.Empty;

	/// <summary>
	///		FirstLevelNavigationPath 转化为的绝对 URI
	/// </summary>
	private string AbsoluteFirstLevelNavigationPathUri
	{
		get
		{
			string uri = Nav.ToAbsoluteUri(FirstLevelNavigationPath).ToString();
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

	private bool ShouldDisplay
	{
		get
		{
			Uri href_uri = new(AbsoluteFirstLevelNavigationPathUri);
			Uri current_uri = new(AbsoluteCurrentUri);
			return href_uri.IsBaseOf(current_uri);
		}
	}
}
