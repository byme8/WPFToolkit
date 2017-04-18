using System;
using Microsoft.Extensions.DependencyInjection;

namespace WpfToolkit.Services
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
            var serviceCollection = new ServiceCollection();
            addServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}