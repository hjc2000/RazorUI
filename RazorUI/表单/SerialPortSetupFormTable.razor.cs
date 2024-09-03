using JCNET;
using Microsoft.AspNetCore.Components;
using System.IO.Ports;

namespace RazorUI.表单;

#pragma warning disable CA1416 // 验证平台兼容性

/// <summary>
///		串口设置表单
/// </summary>
public partial class SerialPortSetupFormTable
{
	/// <summary>
	///		连接按钮点击事件回调函数。
	/// </summary>
	[Parameter]
	public EventCallback<SerialPortOptions> ConnectButtonClickCallback { get; set; }

	private SerialPortOptions _serial_port_options = new();
	private SemaphoreSlim _connect_lock = new(1);

	/// <summary>
	///		获取系统中所有可用的串口的端口名。
	/// </summary>
	public string[] PortNames
	{
		get
		{
			string[] names = SerialPort.GetPortNames();
			if (names.Length > 0 && _serial_port_options.PortName == string.Empty)
			{
				_serial_port_options.PortName = names[0];
				StateHasChanged();
			}

			return names;
		}
	}

	private string BaudRateString
	{
		get
		{
			return _serial_port_options.BaudRate.ToString();
		}
		set
		{
			bool parse_result = int.TryParse(value, out int parse_out);
			if (parse_result)
			{
				_serial_port_options.BaudRate = parse_out;
			}
		}
	}

	private async Task OnConnectButtonClickAsync()
	{
		if (_serial_port_options.PortName == string.Empty)
		{
			return;
		}

		try
		{
			using LockGuard l = new(_connect_lock);
			await l.WaitAsync();
			StateHasChanged();
			await ConnectButtonClickCallback.InvokeAsync(_serial_port_options);
		}
		catch
		{

		}
	}
}

/// <summary>
///		串口选项
/// </summary>
public struct SerialPortOptions
{
	/// <summary>
	///		串口选项
	/// </summary>
	public SerialPortOptions()
	{

	}

	/// <summary>
	///		端口名
	/// </summary>
	public string PortName { get; set; } = string.Empty;

	/// <summary>
	///		波特率
	/// </summary>
	public int BaudRate { get; set; } = 115200;

	/// <summary>
	///		校验方式
	/// </summary>
	public Parity Parity { get; set; } = Parity.Even;

	/// <summary>
	///		停止位
	/// </summary>
	public StopBits StopBits { get; set; } = StopBits.One;
}

#pragma warning restore CA1416 // 验证平台兼容性
