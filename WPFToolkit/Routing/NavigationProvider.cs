using System;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Controls;
using WpfToolkit.Routing.Abstractions;
using WpfToolkit.Routing.Messages;

namespace WpfToolkit.Routing
{
    public class NavigationProvider : Frame
    {
        public NavigationProvider(INavigator navigator)
        {
            this.Subscribe(navigator);
            this.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }

        private void Subscribe(INavigator navigator)
        {
            navigator.Navigations.OfType<Back>().
                Where(_ => this.CanGoBack).
                Subscribe(message => this.GoBack());

            navigator.Navigations.OfType<Navigate>().
                Subscribe(message => this.Navigate(message.View));
        }
    }
}