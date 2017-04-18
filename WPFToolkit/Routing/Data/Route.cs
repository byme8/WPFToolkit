using System;

namespace WpfToolkit.Routing.Data
{
    public class Route
    {
        public Type View
        {
            get;
            set;
        }

        public Type ViewModel
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public Route(string name, Type view, Type viewModel)
        {
            this.Name = name;
            this.View = view;
            this.ViewModel = viewModel;
        }
    }
}