using Xunit;
using OrderServise;
using System;
using System.Collections.Generic;
using FluentAssertions;
using OrderServise.CustomExteption;

namespace OrderServiceTest
{
    public class OrderItemTest
    {
        [Fact]
        public void OrderItems_Should_Be_Created()
        {
            var orderItem = new OrderItems(2, "Pincel");

            Assert.Equal(2, orderItem.Count);
            Assert.Equal("Pincel", orderItem.Name);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        [InlineData(-5)]
        public void Should_Input_Not_Be_Negative_Zero_And_More_Than_Three(int item)
        {
            var orderItem = () => new OrderItems(item, "Book");
            orderItem.Should().Throw<OutOfRangeCountExteption>();
        }


    } 
}