using System;
using System.Threading.Tasks;
using BigNumbersMultiplier.Controller;
using BigNumbersMultiplier.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BigNumbersMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() => MainAsync(args)).Wait();
        }

        private static async Task MainAsync(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            await serviceProvider.GetService<MainController>().Run(args);
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // add services
            serviceCollection.AddTransient<IAdderService, AdderService>();
            serviceCollection.AddTransient<IMultiplierService, MultiplierService>();
            serviceCollection.AddTransient<IFactorialService, FactorialService>();

            // add app
            serviceCollection.AddTransient<MainController>();
        }
    }
}
