using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
