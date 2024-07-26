using JCNET;
using Microsoft.Extensions.DependencyInjection;
using RazorUI.导航;
using System.Collections.Generic;
using System.Windows;

namespace Test;

/// <summary>
///		Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
		ServiceCollection serviceCollection = new();
		serviceCollection.InjectStringBuilderLogWriter();

		serviceCollection.AddSingleton<IRedirectUriProvider>((p) =>
		{
			return new DictionaryRedirectUriProvider()
			{
				new KeyValuePair<string, string>("", "home"),
				new KeyValuePair<string, string>("dialog", "dialog/dialog1"),
			};
		});

		serviceCollection.AddScoped<Redirector>();
		serviceCollection.AddWpfBlazorWebView();
		Resources.Add("services", serviceCollection.BuildServiceProvider());
	}
}
