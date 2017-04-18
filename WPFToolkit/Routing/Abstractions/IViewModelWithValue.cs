namespace WpfToolkit.Routing.Abstractions
{
    public interface IViewModelWithValue
    {
        object Value
        {
            get;
            set;
        }
    }

    public interface IViewModelWithValue<TValue> : IViewModelWithValue
    {
        new TValue Value
        {
            get;
            set;
        }
    }
}