using OrderService;
using OrderServiceTest.Buliders;
using System.Collections.Generic;

namespace OrderServiceTest.Bulider
{
    public class OrderBulider
    {
		private int _userId;
		private List<OrderItem> _orderItems = new();
		OrderItem orderItem = new OrderItemBuilder().Build();

        public OrderBulider()
		{
			_userId = 12;
			_orderItems.Add(orderItem);
		}


		public OrderBulider WithUserId(int userId)
		{
			_userId = userId;
			return this;
		}

		public OrderBulider WithOrderItems(List<OrderItem> orderItems)
		{
			_orderItems = orderItems;
			return this;
		}

		public OrderBulider WithOrderItem(OrderItem orderItem)
		{
			this.orderItem = orderItem;
			return this;
		}

		public Order Build()
		{
			var order = new Order(_userId, _orderItems);
			return order;
		}
	}
}
