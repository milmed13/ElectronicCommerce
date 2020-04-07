namespace OrderApplication.Orders.Get
{
    public class OrderGetCommand
    {
        public OrderGetCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}