using Microsoft.AspNetCore.Components;
using DomainOrder = OrderDomain.Models.OrderAggregate;

namespace Web.Pages.Order.Components.OrderCard
{
    public class OrderCardBase : ComponentBase
    {
        [Parameter]
        public DomainOrder.Order Order { get; set; }

        protected string Title
        {
            get
            {
                return Order.OrderNumber.Value;
            }
        }

        protected string Contents
        {
            get
            {
                return Order.OrderDate.ToLongDateString();
            }
        }
    }
}