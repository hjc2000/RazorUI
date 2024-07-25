using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace RazorUI.Layout;

/// <summary>
///		二级导航菜单按钮。用来被放置到 SecondaryNavMenu 组件中。
///		<br/>* 通过设置 Href 属性，使得点击后能够导航到指定路径。同时，当前路径如果是 Href
///			   的子路径，本组件会高亮。
/// </summary>
public partial class SecondaryNavMenuButton : IAsyncDisposable
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
	///		本按钮要导航到的路径。
	/// </summary>
	[Parameter]
	public string Href { get; set; } = string.Empty;

	/// <summary>
	///		Href 转化为的绝对 URI
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
	///		只要 CurrentRelativeUri 是 RelativeHrefUri 的子 URI 就应该聚焦。
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

	/// <summary>
	///		左内容，用来放置图标。
	/// </summary>
	[Parameter]
	public RenderFragment? Left { get; set; }

	/// <summary>
	///		右内容，用来放置文字。
	/// </summary>
	[Parameter]
	public RenderFragment? Right { get; set; }
}
