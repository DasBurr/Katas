using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vending_Machine.Extensions;

namespace Vending_Machine
{
    public class StartUp
    {
        public IConfiguration Configuration { get; set; }

        public StartUp(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.RegisterDependencies();

            return services.BuildServiceProvider();
        }
    }
}
