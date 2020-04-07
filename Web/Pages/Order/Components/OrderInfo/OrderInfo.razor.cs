using Microsoft.AspNetCore.Components;
using OrderApplication.Orders;
using DomainOrder = OrderDomain.Models.OrderAggregate;
using OrderApplication.Orders.Get;
using System.Threading.Tasks;

namespace Web.Pages.Order.Components.OrderInfo
{
    public class OrderInfoBase : ComponentBase
    {
        [Parameter]
        public int OrderId { get; set; }

        [Inject]
        protected OrderApplicationService orderApplicationService { get; set; }

        protected DomainOrder.Order order; // EFのEntityとドメインのEntity名がかぶる...

        protected override async Task OnInitializedAsync()
        {
            await init();
        }

        private async Task init()
        {
            var orderGetCommand = new OrderGetCommand(OrderId);
            var orderGetResult = await orderApplicationService.Get(orderGetCommand);
            order = orderGetResult.Order;
        }
    }
}