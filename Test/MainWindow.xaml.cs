using JCNET;
using Microsoft.Extensions.DependencyInjection;
using RazorUI.导航;
using System.Windows;

namespace Test;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
		ServiceCollection serviceCollection = new();
		serviceCollection.InjectStringBuilderLogWriter();
		serviceCollection.AddSingleton<IRedirectUriProvider, RedirectUriProvider>();
		serviceCollection.AddWpfBlazorWebView();
		Resources.Add("services", serviceCollection.BuildServiceProvider());
	}
}

internal class RedirectUriProvider : IRedirectUriProvider
{
	public string GetRedirectUri(string relative_uri)
	{
		switch (relative_uri)
		{
		case "":
			{
				return "home";
			}
		case "dialog":
			{
				return "dialog/dialog1";
			}
		}

		return "";
	}
}