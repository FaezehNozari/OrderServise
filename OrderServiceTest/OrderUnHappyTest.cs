using FluentAssertions;
using OrderService;
using OrderService.CustomExteption;
using OrderServise.CustomExteption;
using System.Collections.Generic;
using Xunit;

namespace OrderServiceTest
{
    public class OrderUnHappyTest
    {
        [Fact]
        public void OrderItem_Should_Throw_CantDeleteItemExteption_When_Count_Equal_One()
        {
            var orderItem = new OrderItem(1, "Case");
            List<OrderItem> orderItems = new List<OrderItem>
            {
                orderItem
            };
            var order = new Order(12, orderItems);

            var result = () => order.DeleteItem(orderItem);
            result.Should().Throw<CantDeleteItemExteption>();
        }
        [Fact]
        public void OrderItem_Should_Throw_NullOrderItemException_When_OrderItem_Is_Null()
        {
            var orderItem = new OrderItem(2, null);
            List<OrderItem> orderItems = new List<OrderItem>
            {
               orderItem
            };
            var order = new Order(13 ,null);

            var result = () => order.DeleteItem(null); ; ;
            result.Should().Throw<NullOrderItemException>();
        }
    }
}
