using FluentAssertions;
using OrderService;
using OrderService.CustomException;
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
            var orderItem1 = new OrderItem(1 , "Cpu");
            var orderItem2 = new OrderItem(1, "Cpu");
            List<OrderItem> orderItems = new List<OrderItem>
            {
                orderItem1,
                orderItem2
            };
            var order = new Order(14, orderItems);

            order.Finalized();
            var result = () => order.DeleteItem(orderItem1);

            result.Should().Throw<DeleteItemException>();
        }

        [Fact]
        public void FinalizedMethod_Should_Throw_StateException_When_StateType_Is_Shipped()
        {
            var orderItem = new OrderItem(3, "Mouse");
            List<OrderItem> orderItems = new List<OrderItem>
            {
                orderItem
            };
            var order = new Order(10, orderItems);

            order.Finalized();
            order.Shipped();
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
        
        [Fact]
        public void OrderItem_Should_Throw_AddItemException_When_OrderState_Is_Not_Created()
        {
            var orderItem1 = new OrderItem(1, "Cpu");
            List<OrderItem> orderItems = new List<OrderItem>
            {
                orderItem1,
            };
            var order = new Order(14, orderItems);

            order.Finalized();
            var result = () => order.AddItem(orderItem1);

            result.Should().Throw<AddItemException>();
        }

        [Fact]
        public void OrderItem_Should_Throw_NullOrderItemException_When_Add_Null_To_OrderItem()
        {
            var order = new Order(2, null);

            var addItem = () => order.AddItem(null);

            addItem.Should().Throw<NullOrderItemException>();
        }
    }
}
