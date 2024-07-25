﻿using JCNET;
using Microsoft.Extensions.DependencyInjection;
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
		serviceCollection.AddWpfBlazorWebView();
		Resources.Add("services", serviceCollection.BuildServiceProvider());
	}
}
