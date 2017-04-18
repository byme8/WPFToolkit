using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using WpfToolkit.Routing.Abstractions;
using WpfToolkit.Routing.Data;

namespace WpfToolkit.Routing
{
    public static class Routes
    {
        private static RouteCollection routes;

        static Routes()
        {
            routes = new RouteCollection();
        }

        public static void Configure(Action<IRouteCollection> addRoutes)
        {
            addRoutes(routes);
        }

        public static void AddRouting(this IServiceCollection container)
        {
            if (!routes.Any())
            {
                throw new InvalidOperationException("Define some routes");
            }

            container.AddSingleton<NavigationProvider>();
            container.AddSingleton<INavigator, Navigator>();
            container.AddSingleton<IViewResolver, Navigator>();
            container.AddSingleton<IRouteCollection>(routes);
        }
    }
}