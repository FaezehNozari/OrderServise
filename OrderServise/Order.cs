// See https://aka.ms/new-console-template for more information

using OrderService.CustomExteption;
using OrderServise.CustomExteption;

public class Order
{
    public int UserID { get; set; }
    public  StatesType State { get; private set; }
    public static List<OrderItems> OrderItem { get; set; }
    public OrderItems OrderItem1 { get; }

    public Order(int userID, List<OrderItems> orderItem)
    {
        UserID = userID;
        State = StatesType.Created;
        OrderItem = orderItem;
    }

    public   void DeleteItem(OrderItems orderItem)
    {
        if (OrderItem != null)
        {
            if (State == StatesType.Created)
                OrderItem.Remove(orderItem);
            if (State == StatesType.Finalized || State == StatesType.Shipped)
                new DeleteItemExteption();
        }
        else
            new ListEmptyExteption();
    }

    public  void AddItem(List<OrderItems> orderItem)
    {
        if (State == StatesType.Created)
            OrderItem.AddRange(orderItem);
        if (State == StatesType.Finalized || State == StatesType.Shipped)
            new AddItemExteption();

    }
  
    public void ChengeState(StatesType stateType)
    {
        if (stateType == StatesType.Created)
            State = StatesType.Finalized;
        if (stateType == StatesType.Finalized)
            State = StatesType.Shipped;
    }
}
public enum StatesType
{
    Created,
    Finalized,
    Shipped
}

