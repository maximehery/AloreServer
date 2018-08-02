﻿namespace Alore.Navigator
{
    using API;
    using API.Navigator;
    using Microsoft.Extensions.DependencyInjection;

    internal class NavigatorService : IService
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<NavigatorDao>();
            serviceCollection.AddSingleton<NavigatorRepository>();
            serviceCollection.AddSingleton<INavigatorController, NavigatorController>();
        }
    }
}