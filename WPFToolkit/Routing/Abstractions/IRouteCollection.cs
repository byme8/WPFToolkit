using System.Collections.Generic;
using WpfToolkit.Routing.Data;

namespace WpfToolkit.Routing.Abstractions
{
    public interface IRouteCollection : IEnumerable<Route>
    {
        void Add<TView, TViewModel>(string route)
            where TView : class, IView
            where TViewModel : class;
    }
}