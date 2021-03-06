﻿namespace Alore.Config
{
    using Alore.API;
    using Alore.API.Config;
    using Microsoft.Extensions.DependencyInjection;

    public class ConfigService : IService
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ConfigRepository>();
            serviceCollection.AddSingleton<IConfigController, ConfigController>();
        }
    }
}
