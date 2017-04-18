namespace WpfToolkit.Routing.Abstractions
{
    public interface IViewResolver
    {
        IView ResolveView<TValue>(string routeName, TValue param)
            where TValue : class;

        IView ResolveView(string routeName);
    }
}