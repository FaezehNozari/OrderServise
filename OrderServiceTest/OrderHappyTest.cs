using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OrderService;
using FluentAssertions;

namespace OrderServiceTest
{
    public class OrderHappyTest
    {
        [Fact]
        public void Should_Be_Created()
        {
            var orderItem = new OrderItems(1 , "Keyboard");
            var list = new List<OrderItems>();
            list.Add(orderItem);

            var order = new Order(10, list);

            order.Equals(order);
        }

        [Fact]
        public void OrderState_Should_Be_Created_When_Order_Created()
        {
            var orderItem = new OrderItems(2, "Manitor");
            var list = new List<OrderItems>();
            list.Add(orderItem);

            var order = new Order(10, list);
            order.State.Should().Be(StatesType.Created);

        }

        [Fact]
        public void Order_Deleted_When_State_Is_Created()
        {
            var orderList = new List<OrderItems>();
            var orderItem = new OrderItems(3 , "Mouse" );
            orderList.Add(orderItem);
            var orderItem1 = new OrderItems(4, "Speaker");
            orderList.Add(orderItem1);
            var order = new Order(12 , orderList);

            order.DeleteItem(orderItem);
            order.Equals(orderList);
        }

        [Fact]
        public void Order_Added_When_State_Is_Created()
        {
            var orderItem = new OrderItems(5, "Microphone");
            var list = new List<OrderItems>();
            list.Add(orderItem);
            var order = new Order(19, list);

            order.AddItem(list);
            order.Equals(list);
        }
    }
}
