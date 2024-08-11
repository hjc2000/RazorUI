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
		serviceCollection.InjectRedirector();
		serviceCollection.AddWpfBlazorWebView();
		Resources.Add("services", serviceCollection.BuildServiceProvider());
	}
}

internal static class Injector
{
	public static void InjectRedirector(this IServiceCollection services)
	{
		// 添加重定向 URI 提供者
		services.AddSingleton<IRedirectUriProvider>((p) =>
		{
			return new DictionaryRedirectUriProvider()
			{
				new KeyValuePair<string, string>("", "home"),
				new KeyValuePair<string, string>("dialog", "dialog/dialog1"),
				new KeyValuePair<string, string>("debug", "debug/log"),
			};
		});

		// 添加重定向器
		services.AddScoped<Redirector>();
	}
}
