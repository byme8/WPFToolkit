using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfToolkit.Forms.Toolkit.Services;

namespace WpfToolkit.ViewModels.Injection
{
	public class Injector
	{
		public static readonly DependencyProperty ViewModelProperty =
					DependencyProperty.RegisterAttached("ViewModel", 
						typeof(Type), 
						typeof(Injector), 
						new UIPropertyMetadata(null, ViewModelChanged));

		private static void ViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var view = d as FrameworkElement;
			view.DataContext = Services.ServiceProvider.GetService(e.NewValue as Type);
		}

		public static Type GetViewModel(FrameworkElement view)
		{
			return view.DataContext?.GetType();
		}

		public static void SetViewModel(FrameworkElement view, Type viewModelType)
		{
			view.DataContext = Services.ServiceProvider.GetService(viewModelType);
		}
	}
}
