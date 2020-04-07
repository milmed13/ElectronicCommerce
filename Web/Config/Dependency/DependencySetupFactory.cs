using System;
using Microsoft.Extensions.Configuration;

namespace Web.Config.Dependency
{
    public class DependencySetupFactory
    {
        public IDependencySetup CreateSetup(IConfiguration configuration)
        {
            var setupName = configuration["Dependency:setup"];

            var instance = setupName switch
            {
                nameof(EFDependencySetup) => new EFDependencySetup(configuration),
                _ => new EFDependencySetup(configuration)
                // _ => throw new NotSupportedException(setupName + " is not registered.")
            };

            return instance;
        }
    }
}