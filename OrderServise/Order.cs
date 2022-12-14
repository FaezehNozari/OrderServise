using OrderService.CustomException;
using OrderService.CustomExteption;
using OrderServise.CustomExteption;

namespace OrderService
{
    public class Order
    {
        
        public int UserID { get; private set; }
        public StatesType State { get; private set; }
        public List<OrderItem> OrderItems { get; private set; } = new();
        public Order(int userID, List<OrderItem> orderItemList)
        {
            UserID = userID;
            State = StatesType.Created;
            OrderItems.AddRange(orderItemList);
        }

        public void DeleteItem(OrderItem orderItem)
        {
            if (OrderItems.Count == 1)
            {
                throw new CantDeleteItemExteption();
            }

            if (State != StatesType.Created)
            {
                throw new DeleteItemException();
            }

            OrderItems.Remove(orderItem);
        }

        public void AddItem(OrderItem orderItem)
        {
            if (orderItem is null)
            {
                throw new NullOrderItemException();
            }

            if (State != StatesType.Created)
            {
                throw new AddItemException();
            }

            OrderItems.Add(orderItem);
        }

        public void Finalized()
        {
            if (State == StatesType.Shipped)
                throw new StateException();

            State = StatesType.Finalized;
        }

        public void Shipped()
        {
            if (State == StatesType.Created)
                throw new StateException();

            State = StatesType.Shipped;
        }
    }

   

    public enum StatesType
    {
        Created,
        Finalized,
        Shipped
    }
}
