using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfToolkit.Forms;
using WpfToolkit.Routing.Abstractions;
using WpfToolkit.Routing.Messages;

namespace WpfToolkit.Routing
{
	public class NavigationProvider : Frame
	{
		public NavigationProvider(INavigator navigator)
		{
			this.Subscribe(navigator);
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
