using Microsoft.Extensions.DependencyInjection;

namespace Daily.Common.Interfaces
{
    public interface IPlatformInitializer
    {
        void ConfigureServices(IServiceCollection services);
    }
}
