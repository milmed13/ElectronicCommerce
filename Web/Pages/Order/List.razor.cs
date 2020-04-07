using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using OrderApplication.Orders;
using DomainOrder = OrderDomain.Models.OrderAggregate;

namespace Web.Pages.Order
{
    public class ListBase : ComponentBase
    {
        protected List<DomainOrder.Order> Orders { get; set; }

        [Inject]
        protected OrderApplicationService orderApplicationService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await init();
        }

        private async Task init()
        {
            var orders = await orderApplicationService.GetAllAsync();
            Orders = orders.Orders;
        }
    }
}