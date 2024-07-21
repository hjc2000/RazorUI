using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Test;
/// <summary>
/// DialogWindow.xaml 的交互逻辑
/// </summary>
public partial class DialogWindow : Window
{
	public DialogWindow()
	{
		InitializeComponent();
		ServiceCollection serviceCollection = new();
		serviceCollection.AddWpfBlazorWebView();
		Resources.Add("services", serviceCollection.BuildServiceProvider());
	}
}
