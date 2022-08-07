using FluentAssertions;
using OrderService;
using System.Collections.Generic;
using Xunit;

namespace OrderServiceTest
{
    public class OrderHappyTest
    {
        [Fact]
        public void Should_Be_Created()
        {
            var orderItem = new OrderItem(1, "Keyboard");
            var expectedOrderItems = new List<OrderItem>
            {
                orderItem
            };
            var order = new Order(12, expectedOrderItems);

            Assert.Equal(expectedOrderItems, order.OrderItems);
            Assert.Equal(12, order.UserID);
        }

        [Fact]
        public void OrderState_Should_Be_Created_When_Order_Create()
        {
            var orderItem = new OrderItem(2, "Manitor");
            var orderItems = new List<OrderItem>
            {
                orderItem
            };
            var order = new Order(10, orderItems);

            order.State.Should().Be(StatesType.Created);
        }

        [Fact]
        public void OrderItem_Should_Be_Deleted()
        {
            var orderItem1 = new OrderItem(3, "Mouse");
            var orderItem2 = new OrderItem(2, "Speaker");
            var orderList = new List<OrderItem>
            {
                orderItem1,
                orderItem2
            };
            var order = new Order(12, orderList);

            List<OrderItem> expectedOrderItems = new()
            {
                orderItem1
            };


            order.DeleteItem(orderItem2);

            order.OrderItems.Should().BeEquivalentTo(expectedOrderItems);
        }

        [Fact]
        public void OrderItem_Should_Be_Added()
        {
            var orderItem1 = new OrderItem(3, "Mouse");
            var orderItem2 = new OrderItem(2, "Speaker");
            List<OrderItem> orderItems = new()
            {
                orderItem1
            };
            List<OrderItem> expectedOrderItems = orderItems;
            expectedOrderItems.Add(orderItem2);
            var order = new Order(19, orderItems);

            order.AddItem(orderItem2);

            Assert.Equal(expectedOrderItems, order.OrderItems);
        }

        [Fact]
        public void OrderState_Should_Change_To_Finalized_When_Calling_Finalized_Method()
        {
            var orderItem = new OrderItem(3, "Mouse");
            List<OrderItem> orderItems = new List<OrderItem>
            {
                orderItem
            };
            var order = new Order(10, orderItems);

            order.Finalized();
            order.State.Should().Be(StatesType.Finalized);
        }

        [Fact]
        public void OrderState_Should_Change_To_Shipped_When_Calling_Shipped_Methode()
        {
            var orderItem = new OrderItem(1, "CD");
            List<OrderItem> orderItems = new List<OrderItem>
            {
                orderItem
            };
            var order = new Order(11, orderItems);

            order.Finalized();
            order.Shipped();

            order.State.Should().Be(StatesType.Shipped);
        }
    }
}
