using System;
using System.Windows;

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
            view.DataContext = Services.Services.ServiceProvider.GetService(e.NewValue as Type);
        }

        public static Type GetViewModel(FrameworkElement view)
        {
            return view.DataContext?.GetType();
        }

        public static void SetViewModel(FrameworkElement view, Type viewModelType)
        {
            view.DataContext = Services.Services.ServiceProvider.GetService(viewModelType);
        }
    }
}