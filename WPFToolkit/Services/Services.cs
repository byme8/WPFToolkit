using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace WpfToolkit.Forms.Toolkit.Services
{
	public static class Services
	{
		public static IServiceProvider ServiceProvider
		{
			get;
			private set;
		}

		public static void Configure(Action<IServiceCollection> addServices)
		{
			var services = new ServiceCollection();

			addServices(services);

			ServiceProvider = services.BuildServiceProvider();
		}
	}
}
