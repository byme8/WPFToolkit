using System;
using System.Collections.Generic;
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

        void Navigate<TValue>(string route, TValue data)
            where TValue : class;

        void Back();
    }
}