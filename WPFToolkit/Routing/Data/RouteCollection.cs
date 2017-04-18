using System;
using System.Collections;
using System.Collections.Generic;
using WpfToolkit.Routing.Abstractions;

namespace WpfToolkit.Routing.Data
{
    public class RouteCollection : IRouteCollection
    {
        private List<Route> routes = new List<Route>();

        public void Add<TView, TViewModel>(string route)
            where TView : class, IView
            where TViewModel : class
        {
            var view = typeof(TView);
            var viewModel = typeof(TViewModel);
            var disposable = typeof(IDisposable);

            this.routes.Add(new Route(route, view, viewModel));
        }

        public IEnumerator<Route> GetEnumerator()
        {
            return this.routes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.routes.GetEnumerator();
        }
    }
}