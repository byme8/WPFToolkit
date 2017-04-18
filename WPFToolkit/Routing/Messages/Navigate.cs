using WpfToolkit.Routing.Abstractions;

namespace WpfToolkit.Routing.Messages
{
    public class Navigate : INavigationMessage
    {
        public Navigate(IView view)
        {
            this.View = view;
        }

        public IView View
        {
            get;
        }
    }
}