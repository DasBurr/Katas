using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Vending_Machine_Kata;

namespace Vending_Machine
{
    class Program
    {
        public static IConfiguration Configuration { get; set; }
        static void Main()
        {
            var startUp = new StartUp(Configuration);

            var serviceProvider = startUp.ConfigureServices(new ServiceCollection());

            Console.WriteLine("Insert a coin by 5|2 for nickel, 2|17 for dime and 5|24 for quater");
            Console.WriteLine("Type 'p' for products");
            Console.WriteLine("To buy a product enter code");
            Console.WriteLine("To return coins type 'r'");

            serviceProvider.GetService<VendingMachine>().Run();
        }
    }
}
