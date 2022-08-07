using OrderService;

namespace OrderServiceTest.Buliders
{
    public class OrderItemBuilder
    {
		private int _count;
		private string _name;

		public OrderItemBuilder()
		{
			_count = 1;
			_name = "Speaker";
		}


		public OrderItemBuilder WithCount(int count)
		{
			_count = count;
			return this;
		}

		public OrderItemBuilder WithName(string name)
		{
			_name = name;
			return this;
		}

		public OrderItem Build()
		{
			var orderItem = new OrderItem(_count, _name);
			return orderItem;
		}
	}
}
