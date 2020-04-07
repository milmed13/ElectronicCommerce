using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OrderDomain.Models.OrderAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Orders
{
    public class OrderRepository : IOrderRepository
    {
        public OrderRepository(EcDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        private readonly EcDbContext context;

        public async Task<Order> GetByIdWithItemsAsync(int id)
        {
            return await context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await context.Orders.ToListAsync();
        }

        public void Save(Order order)
        {
            var found = context.Orders.Find(order.Id);

            if (found == null)
            {
                context.Orders.Add(order);
            }
            else
            {
                context.Orders.Update(order);
            }

            context.SaveChanges();
        }
    }
}