using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vending_Machine.Extensions;

namespace Vending_Machine
{
    public class StartUp
    {
        public ServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.RegisterDependencies();

            return services.BuildServiceProvider();
        }
    }
}
