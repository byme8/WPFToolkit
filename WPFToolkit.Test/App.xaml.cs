using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WpfToolkit.Forms.Toolkit.Services;
using WpfToolkit.Routing;
using WpfToolkit.Routing.Abstractions;
using WPFToolkit.Test.ViewModels;
using WPFToolkit.Test.Views;

namespace WPFToolkit.Test
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			Routes.Configure(routes =>
			{
				routes.Add<MainTestView, MainTestViewModel>("home");
			});

			Services.Configure(services =>
			{
				services.AddRouting();
				services.AddSingleton<IntViewModel>();
				services.AddSingleton<StringViewModel>();
				services.AddSingleton<DoubleViewModel>();
			});
		}
	}
}
