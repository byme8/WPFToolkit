using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WpfToolkit.Forms.Toolkit.Services;
using WpfToolkit.Routing.Abstractions;
using WpfToolkit.Routing.Data;

namespace WpfToolkit.Routing
{
	public static class Routes
	{
		private static RouteCollection routes;

		public static void Configure(Action<IRouteCollection> addRoutes)
		{
			routes = new RouteCollection();
			addRoutes(routes);
		}

		public static void AddRouting(this IServiceCollection services)
		{
			services.AddTransient<NavigationProvider>();
			services.AddSingleton<INavigator, Navigator>();
			services.AddSingleton<IRouteCollection>(routes);

			foreach (var route in routes)
			{
				services.AddTransient(route.View);
				services.AddTransient(route.ViewModel);
			}
		}
	}
}
