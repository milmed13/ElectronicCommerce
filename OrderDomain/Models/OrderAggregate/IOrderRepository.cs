using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderDomain.Models.OrderAggregate
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdWithItemsAsync(int id);
        Task<List<Order>> GetAllAsync();
        void Save(Order order);
    }
}