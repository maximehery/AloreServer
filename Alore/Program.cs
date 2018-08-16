﻿namespace Alore
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API;
    using Handshake;
    using Landing;
    using Messenger;
    using Navigator;
    using Network;
    using Player;
    using Room;
    using Alore.Util;
    using Alore.Config;
    using Alore.Item;

    //TODO: Loop all the dao's & call the dispose method to make sure all
    //of the insert queries are being executed before closing the application.
    public class Program
    {
        private Listener _listener;

        private async Task Run()
        {
            IList<IService> services = new List<IService>
            {
                new HandshakeService(),
                new LandingService(),
                new MessengerService(),
                new NavigatorService(),
                new PlayerService(),
                new RoomService(),
                new ConfigService(),
                new ItemService()
            };
            
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder => builder.AddConsole());

            foreach (IService service in services)
            {
                service.ConfigureServices(serviceCollection);
            }

            //Loops over all the types and registers all the packets!
            serviceCollection.RegisterAllPackets();
            serviceCollection.AddSingleton<IEventProvider, EventProvider>();
            serviceCollection.AddSingleton<Listener>();

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            _listener = serviceProvider.GetService<Listener>();

            await _listener.Listen(30000);

            while (true)
            {
                if (Console.ReadKey(false).Key == ConsoleKey.Enter)
                {
                    await DisposeAsync();
                }
            }
        }
        
        private async Task DisposeAsync()
        {
            await _listener.DisposeAsync();

            Environment.Exit(0);
        }

        public static async Task Main()
        {
            await new Program().Run();
        }
    }
}