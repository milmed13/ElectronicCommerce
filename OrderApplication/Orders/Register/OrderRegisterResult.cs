namespace OrderApplication.Orders.Register
{
    public class OrderRegisterResult
    {
        public OrderRegisterResult(int createOrderId)
        {
            CreateOrderId = createOrderId;
        }

        public int CreateOrderId { get; private set; }
    }
}