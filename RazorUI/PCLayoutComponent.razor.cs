using JSInteropLib;
using Microsoft.AspNetCore.Components;

namespace RazorUI;

public partial class PCLayoutComponent
{
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

	[Parameter]
	public RenderFragment? LeftBarContent { get; set; }

	[Parameter]
	public RenderFragment? LeftMenu { get; set; }

	[Parameter]
	public RenderFragment? TopBar { get; set; }

	[Parameter]
	public RenderFragment? Content { get; set; }

	[Parameter]
	public RenderFragment? StateBar { get; set; }

	[Parameter]
	public string Width { get; set; } = "100vw";
	[Parameter]
	public string Height { get; set; } = "100vh";

	[Parameter]
	public string LeftBarWidth { get; set; } = "40px";
	[Parameter]
	public string LeftBarBackgroundColor { get; set; } = "darkslateblue";
	[Parameter]
	public string LeftBarFontColor { get; set; } = "white";

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
