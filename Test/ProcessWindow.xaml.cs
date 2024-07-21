using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace Test;

/// <summary>
/// ProcessWindow.xaml 的交互逻辑
/// </summary>
public partial class ProcessWindow : Window
{
	public ProcessWindow()
	{
		InitializeComponent();
	}
}

public class MyHwnd : HwndHost
{
	protected override unsafe HandleRef BuildWindowCore(HandleRef hwndParent)
	{
		// 创建非托管窗口
		_hwnd = CreateWindowEx(
			0,
			"STATIC",
			null,
			WS_VISIBLE | WS_CHILD,
			0, 0,
			100, 200,
			hwndParent.Handle, IntPtr.Zero,
			GetModuleHandle(null),
			IntPtr.Zero);

		if (_hwnd == IntPtr.Zero)
		{
			throw new Win32Exception();
		}

		return new HandleRef(this, _hwnd);
	}

	protected override void DestroyWindowCore(HandleRef hwnd)
	{
		// 销毁非托管窗口
		DestroyWindow(hwnd.Handle);
	}

	private IntPtr _hwnd;

	#region Win32 API declarations
	[DllImport("user32.dll")]
	private static extern IntPtr CreateWindowEx(
		int dwExStyle,
		string lpClassName,
		string? lpWindowName,
		int dwStyle,
		int x, int y,
		int nWidth, int nHeight,
		IntPtr hWndParent,
		IntPtr hMenu,
		IntPtr hInstance,
		IntPtr lpParam);

	[DllImport("user32.dll")]
	private static extern bool DestroyWindow(IntPtr hWnd);

	[DllImport("kernel32.dll")]
	private static extern IntPtr GetModuleHandle(string? lpModuleName);
	#endregion

	#region Window styles and flags
	private const int WS_VISIBLE = 0x10000000;
	private const int WS_CHILD = 0x40000000;
	#endregion
}
