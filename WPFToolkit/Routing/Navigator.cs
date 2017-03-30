using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WpfToolkit.Routing.Abstractions;
using WpfToolkit.Routing.Data;
using WpfToolkit.Routing.Messages;

namespace WpfToolkit.Routing
{
	public class Navigator : INavigator
	{
		public IEnumerable<Route> Routes
		{
			get;
		}

		private ISubject<INavigationMessage> navigations =
			new Subject<INavigationMessage>();

		public IObservable<INavigationMessage> Navigations
			=> navigations;

		public Navigator(IServiceProvider services, IRouteCollection routes)
		{
			this.Services = services;
			this.Routes = routes;
		}

		public IServiceProvider Services
		{
			get;
		}
				
		public void Back()
		{
			this.navigations.OnNext(new Back());
		}

		public void Navigate(string route)
		{
			this.Navigate(route, null);
		}

		public void Navigate(string route, object data)
		{
			this.navigations.OnNext(new Navigate(this.GetResolvedView(route, data)));
		}

		public IView GetResolvedView(string routeName, object param = null)
		{
			var route = this.Routes.First(o => o.Name == routeName);
			var view = this.Services.GetService(route.View) as IView;

			object viewModel = null;

			if (param is null)
				viewModel = this.Services.GetService(route.ViewModel);
			else
				viewModel = Activator.CreateInstance(route.ViewModel, param);

			view.DataContext = viewModel;

			return view;
		}
	}

}
