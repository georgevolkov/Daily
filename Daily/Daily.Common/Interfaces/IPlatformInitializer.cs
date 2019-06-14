using Microsoft.Extensions.DependencyInjection;

namespace Questionnaire.Common.Interfaces
{
    public interface IPlatformInitializer
    {
        void ConfigureServices(IServiceCollection services);
    }
}
