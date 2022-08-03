namespace OrderService.CustomExteption
{
    public class NullOrderItemException : Exception
    {
        public override string Message => "OrderItem Can Not Be Null";
    }
}
