using Infrastructure;
using Infrastructure.Persistence.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderApplication.Orders;
using OrderDomain.Models.OrderAggregate;
using OrderDomain.Services;

namespace Web.Config.Dependency
{
    public class EFDependencySetup : IDependencySetup
    {
        private readonly IConfiguration configuration;

        public EFDependencySetup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Run(IServiceCollection services)
        {
            SetupFactories(services);
            SetupRepositories(services);
            SetupQueryServices(services);
            SetupApplicationServices(services);
            SetupDomainServices(services);
        }

        private void SetupFactories(IServiceCollection services)
        {
            services.AddTransient<IOrderFactory, OrderFactory>();
        }

        private void SetupRepositories(IServiceCollection services)
        {
            services.AddDbContext<EcDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient<IOrderRepository, OrderRepository>();
        }

        private void SetupQueryServices(IServiceCollection services)
        {
        }

        private void SetupApplicationServices(IServiceCollection services)
        {
            services.AddTransient<OrderApplicationService>();
        }

        private void SetupDomainServices(IServiceCollection services)
        {
            services.AddTransient<OrderService>();
        }
    }
}