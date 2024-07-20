using Microsoft.AspNetCore.Components;

namespace RazorUI;

public partial class PCLayoutComponent
{
	private bool _hide_left_menu = false;
	private string UsedLeftMenuWidth
	{
		get
		{
			if (_hide_left_menu)
			{
				return "0";
			}

			return LeftMenuWidth;
		}
	}

	/// <summary>
	///		反转侧边栏的隐藏状态。本来出现的，调用后会隐藏。本来隐藏的，调用后会出现。
	/// </summary>
	/// <returns></returns>
	private void ToggleHideLeftMenu()
	{
		_hide_left_menu = !_hide_left_menu;
	}

	[Parameter]
	public RenderFragment? LeftMenu { get; set; }

	[Parameter]
	public RenderFragment? TopBar { get; set; }

	[Parameter]
	public RenderFragment? Content { get; set; }

	[Parameter]
	public RenderFragment? StateBar { get; set; }

	/// <summary>
	///		“隐藏左侧边栏” 按钮。如果设置了本参数，则内置的按钮将被禁用，转而使用这个
	/// </summary>
	[Parameter]
	public RenderFragment? HideLeftMenuButton { get; set; }

	[Parameter]
	public string Width { get; set; } = "100vw";
	[Parameter]
	public string Height { get; set; } = "100vh";

	[Parameter]
	public string LeftMenuWidth { get; set; } = "200px";

	[Parameter]
	public string LeftMenuBackgroundColor { get; set; } = "unset";

	[Parameter]
	public string LeftMenuBorderStyle { get; set; } = "solid";
	[Parameter]
	public string LeftMenuBorderColor { get; set; } = "gray";
	[Parameter]
	public string LeftMenuBorderWidth { get; set; } = "0";

	[Parameter]
	public string TopBarHeight { get; set; } = "50px";

	[Parameter]
	public string TopBarBackgroundColor { get; set; } = "unset";

	[Parameter]
	public string TopBarBorderStyle { get; set; } = "solid";
	[Parameter]
	public string TopBarBorderColor { get; set; } = "gray";
	[Parameter]
	public string TopBarBorderWidth { get; set; } = "0";
}
