using Microsoft.AspNetCore.Components;

namespace RazorUI.Layout;

/// <summary>
///		���ڷ��õ� PCLayoutComponent ����ఴť���ĵ����������
/// </summary>
public partial class LeftBarNav
{
	/// <summary>
	///		�����ݡ��������� LeftBarNavButton �����
	/// </summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }
}
