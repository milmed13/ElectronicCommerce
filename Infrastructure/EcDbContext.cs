using Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using OrderDomain.Models.OrderAggregate;
using OrderDomain.Interfaces;

namespace Infrastructure
{
    public class EcDbContext : DbContext
    {
        public EcDbContext(DbContextOptions<EcDbContext> options) : base(options)
        {
        }

        public const string ORDER_SCHEMA = "order";

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderItemConfiguration());
        }
    }
}