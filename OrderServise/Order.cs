using OrderService.CustomExteption;
using OrderServise.CustomExteption;

namespace OrderService
{
    public class Order
    {
        public int UserID { get; private set; }
        public StatesType State { get; private set; }
        public List<OrderItem> OrderItems { get; private set; }
        List<OrderItem> orderItemList = new List<OrderItem>();
        public Order(int userID, List<OrderItem> orderItemList)
        {
            UserID = userID;
            State = StatesType.Created;
            this.orderItemList = orderItemList;
            OrderItems = orderItemList;
        }

        public void DeleteItem(OrderItem orderItem)
        {
            if (OrderItems.Count == 1)
            {
                throw new CantDeleteItemExteption();
            }

            if (orderItem == null)
            {
                throw new NullOrderItemException();
            }

            if (State != StatesType.Created)
            {
                throw new DeleteItemExteption();
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
                throw new AddItemExteption();
            }

            OrderItems.Add(orderItem);
        }

        public void Finalized()
        {
            if (State != StatesType.Created)
                throw new StateExteption();

            State = StatesType.Finalized;
        }

        public void Shipped()
        {
            if (State != StatesType.Finalized || State != StatesType.Created)
                throw new StateExteption();

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