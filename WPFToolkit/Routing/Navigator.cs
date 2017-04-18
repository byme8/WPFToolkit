using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using WpfToolkit.Routing.Abstractions;
using WpfToolkit.Routing.Data;
using WpfToolkit.Routing.Messages;

namespace WpfToolkit.Routing
{
    public class Navigator : INavigator, IViewResolver
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
            this.Navigate<object>(route, null);
        }

        public void Navigate<TValue>(string route, TValue data)
            where TValue : class
        {
            this.navigations.OnNext(new Navigate(this.ResolveView(route, data)));
        }

        public IView ResolveView<TValue>(string routeName, TValue param = null)
            where TValue : class
        {
            var route = this.Routes.First(o => o.Name == routeName);
            var view = this.Services.GetService(route.View) as IView;

            object viewModel = null;

            if (param is null)
                viewModel = this.Services.GetService(route.ViewModel);
            else
            {
                viewModel = this.Services.GetService(route.ViewModel);
                if (viewModel is IViewModelWithValue<TValue> viewModelWithValue)
                {
                    viewModelWithValue.Value = param;
                }
                else
                {
                    throw new InvalidOperationException("View model does not support value passing.");
                }
            }

            view.DataContext = viewModel;

            return view;
        }

        public IView ResolveView(string name)
        {
            return this.ResolveView<object>(name, null);
        }
    }
}