using Microsoft.AspNetCore.Components;

namespace RazorUI.Box;

/// <summary>
///		左右布局的盒子。<br/>
///		
///		主体是左右布局，但是实际上支持：
///			<br/>* 最顶上的头部，占据左、中、右 3 个列。
///			<br/>* 第 2 行的头部：左头部、中头部、右头部。
///			<br/>* 内容：左内容、中内容、右内容。
///			<br/>* 倒数第 2 行的脚部：左脚部、中脚部、右脚部
///			<br/>* 最后一行的脚部，占据左、中、右 3 个列。
///			
/// 	<br/>
///			
///		+-----------------------------------+	<br/>
///		|			 最顶上的头部				|	<br/>
///		+-----------------------------------+	<br/>
///		|	左头部	|	中头部	|	右头部	|	<br/>
///		+-----------+-----------+-----------+	<br/>
///		|	左内容	|	中内容	|	右内容   |	<br/>
///		+-----------+-----------+-----------+	<br/>
///		|	左脚部	|	中脚部	|	右脚部   |	<br/>
///		+-----------------------------------+	<br/>
///		|			 最底下的脚部				|	<br/>
///		+-----------------------------------+	<br/>
///		
/// </summary>
public partial class LeftRightLayoutBox
{
	/// <summary>
	///		最顶上的头部，占据 3 列。
	/// </summary>
	[Parameter]
	public RenderFragment? Head { get; set; }

	#region 3 个头部
	/// <summary>
	///		左头部。
	/// </summary>
	[Parameter]
	public RenderFragment? LeftHead { get; set; }

	/// <summary>
	///		中头部。
	/// </summary>
	[Parameter]
	public RenderFragment? MiddleHead { get; set; }

	/// <summary>
	///		右头部。
	/// </summary>
	[Parameter]
	public RenderFragment? RightHead { get; set; }
	#endregion

	#region 3 个内容
	/// <summary>
	///		左内容。
	/// </summary>
	[Parameter]
	public RenderFragment? LeftContent { get; set; }

	/// <summary>
	///		中内容。
	/// </summary>
	[Parameter]
	public RenderFragment? MiddleContent { get; set; }

	/// <summary>
	///		右内容。
	/// </summary>
	[Parameter]
	public RenderFragment? RightContent { get; set; }
	#endregion

	#region 3 个脚部
	/// <summary>
	///		左脚部。
	/// </summary>
	[Parameter]
	public RenderFragment? LeftFoot { get; set; }

	/// <summary>
	///		中脚部。
	/// </summary>
	[Parameter]
	public RenderFragment? MiddleFoot { get; set; }

	/// <summary>
	///		右脚部。
	/// </summary>
	[Parameter]
	public RenderFragment? RightFoot { get; set; }
	#endregion

	/// <summary>
	///		最底下的脚部，占据 3 列。
	/// </summary>
	[Parameter]
	public RenderFragment? Foot { get; set; }

	#region root 样式
	/// <summary>
	///		整体宽度。默认：100%
	/// </summary>
	[Parameter]
	public string Width { get; set; } = "100%";

	/// <summary>
	///		整体高度。默认：100%
	/// </summary>
	[Parameter]
	public string Height { get; set; } = "100%";

	/// <summary>
	///		整体的溢出行为。默认：hidden
	/// </summary>
	[Parameter]
	public string Overflow { get; set; } = "hidden";
	#endregion

	#region 内容样式
	/// <summary>
	///		左内容内边距.默认：0
	/// </summary>
	[Parameter]
	public string LeftContentPadding { get; set; } = "0";

	/// <summary>
	///		中内容内边距。默认：0
	/// </summary>
	[Parameter]
	public string MiddleContentPadding { get; set; } = "0";

	/// <summary>
	///		右内容内边距。默认：0
	/// </summary>
	[Parameter]
	public string RightContentPadding { get; set; } = "0";
	#endregion
}
