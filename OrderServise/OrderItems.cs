using OrderServise.CustomExteption;

namespace OrderService
{
    public class OrderItem
    {
        public int Count { get; set; }
        public string Name { get; set; }
        public OrderItem(int count, string name)
        {
            EnsureCount(count);
            Count = count;
            Name = name;
        }
        public static void EnsureCount(int count)
        {
            if (count <= 0 || count > 3)
                throw new OutOfRangeCountException();
        }
    }
}
