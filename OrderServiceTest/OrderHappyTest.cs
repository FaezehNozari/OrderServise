using FluentAssertions;
using OrderService;
using OrderServiceTest.Bulider;
using OrderServiceTest.Buliders;
using System.Collections.Generic;
using Xunit;

namespace OrderServiceTest
{
    public class OrderHappyTest
    {
        [Fact]
        public void Should_Be_Created()
        {
            var orderItem = new OrderItemBuilder().Build();
            var orderBuilder = new OrderBulider()
                .WithUserId(1)
                .WithOrderItem(orderItem);
            var order = orderBuilder.Build();

            List<OrderItem> expectedOrderItems = new() { orderItem };

            
            order.OrderItems.Should().BeEquivalentTo(expectedOrderItems);
            Assert.Equal(1, order.UserID);
        }

        [Fact]
        public void OrderState_Should_Be_Created_When_Order_Create()
        {
            var orderItem = new OrderItemBuilder().Build();
            var orderBuilder = new OrderBulider()
                .WithUserId(1)
                .WithOrderItem(orderItem);
            var order = orderBuilder.Build();

            order.State.Should().Be(StatesType.Created);
        }

        [Fact]
        public void OrderItem_Should_Be_Deleted()
        {
            var orderItem1 = new OrderItemBuilder().Build();
            var orderItem2 = new OrderItemBuilder().WithCount(1).WithName("Case").Build();
            var orderBuilder = new OrderBulider()
                .WithUserId(1)
                .WithOrderItem(orderItem1);
            List<OrderItem> orderItems = new List<OrderItem>
            {
                orderItem1 ,
                orderItem2
            };
            var order = new OrderBulider().WithOrderItems(orderItems).Build();

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
            var orderItem = new OrderItemBuilder()
                .WithCount(1)
                .WithName("Speaker")
                .Build();
            var order = new OrderBulider()
                .WithOrderItem(orderItem)
                .Build();

            List<OrderItem> expectedOrderItems = new()
            {
                orderItem,
                orderItem
            };

            order.AddItem(orderItem);

            order.OrderItems.Should().BeEquivalentTo(expectedOrderItems);
        }

        [Fact]
        public void OrderState_Should_Change_To_Finalized_When_Calling_Finalized_Method()
        {
            var order = new OrderBulider().Build();

            order.Finalized();

            order.State.Should().Be(StatesType.Finalized);
        }

        [Fact]
        public void OrderState_Should_Change_To_Shipped_When_Calling_Shipped_Methode()
        {
            var order = new OrderBulider().Build();

            order.Finalized();
            order.Shipped();

            order.State.Should().Be(StatesType.Shipped);
        }
    }
}
