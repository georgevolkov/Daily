using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Daily.Common.Interfaces;
using Daily.Data;
using Daily.Data.Interfaces;
using Daily.Service.Interfaces;
using Daily.Service;

namespace Daily.Common
{
    public class PlatformInitializer : IPlatformInitializer
    {
        protected IConfiguration _configuration;

        public PlatformInitializer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // configure database
            ConfigureDatabase(services);

            // add singletone instances
            services.AddSingleton(Mapping.Configuration.CreateDefaultMapper());

            // add scoped registrations
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDailyService, DailyService>();
        }

        protected virtual void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<DbContext, Data.AppContext>(options =>
               options.UseSqlServer(
                   _configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
