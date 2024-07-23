using Microsoft.AspNetCore.Components;

namespace RazorUI.Button;

/// <summary>
///		sat ��ť
/// </summary>
public partial class STButton
{
	/// <summary>
	///		������
	/// </summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	/// <summary>
	///		���ð�ť
	/// </summary>
	[Parameter]
	public bool Disabled { get; set; } = false;

	/// <summary>
	///		�ڲ��� Parameter ����󣬲�������֮ǰδ����� html ��ǩ���ԡ�
	/// </summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public Dictionary<string, object>? CaptureUnmatchedValues { get; set; }
}
