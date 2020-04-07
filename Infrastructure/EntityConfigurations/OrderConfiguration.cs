using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderDomain.Models.OrderAggregate;

namespace Infrastructure.EntityConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders", EcDbContext.ORDER_SCHEMA);
            builder.HasKey(o => o.Id);
            builder.OwnsOne(o => o.OrderNumber, o => o.WithOwner());
            builder.OwnsOne(o => o.Address, a => a.WithOwner());
        }
    }
}