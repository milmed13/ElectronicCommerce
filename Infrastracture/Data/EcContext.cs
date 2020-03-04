using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ElectronicCommerce.Infrastracture.Data
{
    public class EcContext : DbContext
    {
        public EcContext(DbContextOptions<EcContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}