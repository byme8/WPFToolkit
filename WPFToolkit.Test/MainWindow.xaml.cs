using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfToolkit.Forms.Toolkit.Services;
using WpfToolkit.Routing;
using WpfToolkit.Routing.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace WPFToolkit.Test
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			this.InitializeComponent();

			var navigator = Services.ServiceProvider.GetService<INavigator>();
			this.Content = new NavigationProvider(navigator);

			navigator.Navigate("home");
		}
	}
}
