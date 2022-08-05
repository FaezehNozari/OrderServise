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
        public void OrderItem_Should_Throw_DeleteItemException_When_StateType_Not_Created()
        {
            var orderItem = new OrderItem(1 , "Cpu");
            List<OrderItem> orderItems = new List<OrderItem>
            {
                orderItem
            };
            var order = new Order(14, orderItems);

            order.Finalized();
            order.Shipped();
            var result = () => order.DeleteItem(orderItem);
            result.Should().Throw<DeleteItemException>();
        }
        [Fact]
        public void FinalizedMethod_Should_Throw_StateException_When_StateType_Is_Created()
        {
            var orderItem = new OrderItem(3, "Mouse");
            List<OrderItem> orderItems = new List<OrderItem>
            {
                orderItem
            };
            var order = new Order(10, orderItems);

            var finalized = () => order.Finalized();
            finalized.Should().Throw<StateException>();
        }
        [Fact]
        public void ShippedMethod_Should_Throw_StateException_When_OrderState_Is_Craeted()
        {
            var orderItem = new OrderItem(3, "Mouse");
            List<OrderItem> orderItems = new List<OrderItem>
            {
                orderItem
            };
            var order = new Order(10, orderItems);

            var shipped = () => order.Shipped();
            shipped.Should().Throw<StateException>();
        }
    }
}
