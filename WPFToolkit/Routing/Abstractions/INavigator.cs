using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfToolkit.Routing.Data;
using WpfToolkit.Routing.Messages;

namespace WpfToolkit.Routing.Abstractions
{
	public interface INavigator
	{
		IEnumerable<Route> Routes
		{
			get;
		}

		IObservable<INavigationMessage> Navigations
		{
			get;
		}

		void Navigate(string route);
		void Navigate(string route, object data);

		void Back();
	}
}
