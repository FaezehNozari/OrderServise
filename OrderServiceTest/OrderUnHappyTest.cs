using FluentAssertions;
using OrderService;
using OrderService.CustomException;
using OrderService.CustomExteption;
using OrderServiceTest.Bulider;
using OrderServiceTest.Buliders;
using OrderServise.CustomExteption;
using System.Collections.Generic;
using Xunit;

namespace OrderServiceTest
{
    public class OrderUnHappyTest
    {
        [Fact]
        public void Order_Should_Throw_CantDeleteItemExteption_When_OrderItems_Count_Equal_One()
        {
            var orderItem = new OrderItemBuilder().Build();
            var orderBuilder = new OrderBulider()
                 .WithOrderItem(orderItem);
            var order = orderBuilder.Build();

            var result = () => order.DeleteItem(orderItem);

            result.Should().Throw<CantDeleteItemExteption>();
        }
       
        [Fact]
        public void Order_Should_Throw_DeleteItemException_When_StateType_Not_Created()
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

            order.Finalized();
            var result = () => order.DeleteItem(orderItem1);

            result.Should().Throw<DeleteItemException>();
        }

        [Fact]
        public void FinalizedMethod_Should_Throw_StateException_When_StateType_Is_Shipped()
        {
            var order = new OrderBulider().Build();

            order.Finalized();
            order.Shipped();
            var finalized = () => order.Finalized();

            finalized.Should().Throw<StateException>();
        }

        [Fact]
        public void ShippedMethod_Should_Throw_StateException_When_OrderState_Is_Craeted()
        {
            var order = new OrderBulider().Build();

            var shipped = () => order.Shipped();

            shipped.Should().Throw<StateException>();
        }
        
        [Fact]
        public void Order_Should_Throw_AddItemException_When_OrderState_Is_Not_Created()
        {
            var orderItem = new OrderItemBuilder().Build();
            var orderBuilder = new OrderBulider()
                .WithUserId(1)
                .WithOrderItem(orderItem);
            var order = orderBuilder.Build();

            order.Finalized();
            var result = () => order.AddItem(orderItem);

            result.Should().Throw<AddItemException>();
        }

        [Fact]
        public void Order_Should_Throw_NullOrderItemException_When_Add_Null_To_OrderItem()
        {
            var orderBuilder = new OrderBulider().WithOrderItems(null);

            var order = () => orderBuilder.Build();

            order.Should().Throw<NullOrderItemException>();
        }
    }
}
