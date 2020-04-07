using Microsoft.Extensions.DependencyInjection;

namespace Web.Config.Dependency
{
    public interface IDependencySetup
    {
        void Run(IServiceCollection services);
    }
}