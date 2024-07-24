using JCNET;
using Microsoft.Extensions.DependencyInjection;
using System;
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
		serviceCollection.AddSingleton((s) =>
		{
			StringBuilderLogWriter writer = new();
			Console.SetOut(writer);
			return writer;
		});

		serviceCollection.AddWpfBlazorWebView();
		Resources.Add("services", serviceCollection.BuildServiceProvider());
	}
}
