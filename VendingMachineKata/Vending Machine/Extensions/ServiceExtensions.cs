using Microsoft.Extensions.DependencyInjection;
using Vending_Machine_Kata;
using Vending_Machine_Kata.Classes;
using Vending_Machine_Kata.Interfaces;

namespace Vending_Machine.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICoinOperator, CoinOperator>();
            services.AddScoped<IProductDispenser, ProductDispenser>();
            services.AddScoped<IReturnCoinFromSale, CoinReturns>();
            services.AddScoped<IProductStock, ProductStock>();
            services.AddScoped<IProductValidate, ProductValidator>();
            services.AddScoped<ICoinCalculator, CoinCalculator>();
            services.AddScoped<ICoinBank, CoinBank>();
            services.AddScoped<IProductFactoryBasic, ProductFactory>();

            services.AddTransient<VendingMachine>();

            return services;
        }
    }
}
