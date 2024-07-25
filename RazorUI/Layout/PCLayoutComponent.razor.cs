using JSInteropLib;
using Microsoft.AspNetCore.Components;

namespace RazorUI.Layout;

/// <summary>
///		PC 端的布局组件。
/// </summary>
public partial class PCLayoutComponent
{
	/// <summary>
	///		初始化。
	///		会添加 RazorUIGlobalStyle.css 到 head 标签中。
	/// </summary>
	/// <returns></returns>
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		_jsop = new JSOp(JSRuntime);
		_init_tcs.TrySetResult();
		await _jsop.AddCssAsync("./_content/RazorUI/RazorUIGlobalStyle.css");
	}

	private TaskCompletionSource _init_tcs = new();
	private JSOp _jsop = default!;

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

	/// <summary>
	///		左侧按钮条的内容。
	/// </summary>
	[Parameter]
	public RenderFragment? LeftBarContent { get; set; }

	/// <summary>
	///		左侧菜单的内容。
	/// </summary>
	[Parameter]
	public RenderFragment? LeftMenu { get; set; }

	/// <summary>
	///		顶部按钮条的内容。
	/// </summary>
	[Parameter]
	public RenderFragment? TopBar { get; set; }

	/// <summary>
	///		主体内容。
	/// </summary>
	[Parameter]
	public RenderFragment? Content { get; set; }

	/// <summary>
	///		底部状态条的内容。
	/// </summary>
	[Parameter]
	public RenderFragment? StateBar { get; set; }

	/// <summary>
	///		整个布局组件的整体宽度。默认值：100vw
	/// </summary>
	[Parameter]
	public string Width { get; set; } = "100vw";

	/// <summary>
	///		整个布局组件的整体高度。默认值：100vh
	/// </summary>
	[Parameter]
	public string Height { get; set; } = "100vh";

	/// <summary>
	///		左侧按钮条的宽度。默认：50px
	/// </summary>
	[Parameter]
	public string LeftBarWidth { get; set; } = "50px";

	/// <summary>
	///		左侧按钮条的背景色。默认：darkslateblue
	/// </summary>
	[Parameter]
	public string LeftBarBackgroundColor { get; set; } = "darkslateblue";

	/// <summary>
	///		左侧按钮条的字体颜色。默认：white
	/// </summary>
	[Parameter]
	public string LeftBarFontColor { get; set; } = "white";

	/// <summary>
	///		左侧菜单的宽度。默认：200px
	/// </summary>
	[Parameter]
	public string LeftMenuWidth { get; set; } = "200px";

	/// <summary>
	///		左侧菜单的背景色。默认：unset
	/// </summary>
	[Parameter]
	public string LeftMenuBackgroundColor { get; set; } = "unset";

	/// <summary>
	///		左侧菜单的边框样式。默认：solid
	/// </summary>
	[Parameter]
	public string LeftMenuBorderStyle { get; set; } = "solid";

	/// <summary>
	///		左侧菜单的边框颜色。默认：gray
	/// </summary>
	[Parameter]
	public string LeftMenuBorderColor { get; set; } = "gray";

	/// <summary>
	///		左侧菜单的边框宽度。默认：0
	/// </summary>
	[Parameter]
	public string LeftMenuBorderWidth { get; set; } = "0";

	/// <summary>
	///		顶部按钮条的高度。默认：50px
	/// </summary>
	[Parameter]
	public string TopBarHeight { get; set; } = "50px";

	/// <summary>
	///		顶部按钮条的背景色。默认：unset
	/// </summary>
	[Parameter]
	public string TopBarBackgroundColor { get; set; } = "darkslateblue";

	/// <summary>
	///		顶部按钮条的边框样式。默认：solid
	/// </summary>
	[Parameter]
	public string TopBarBorderStyle { get; set; } = "solid";

	/// <summary>
	///		顶部按钮条的边框颜色。默认：gray
	/// </summary>
	[Parameter]
	public string TopBarBorderColor { get; set; } = "gray";

	/// <summary>
	///		顶部按钮条的边框宽度。默认：0
	/// </summary>
	[Parameter]
	public string TopBarBorderWidth { get; set; } = "0";
}
