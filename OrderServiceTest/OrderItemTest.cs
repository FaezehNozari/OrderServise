using Xunit;
using FluentAssertions;
using OrderServise.CustomExteption;
using OrderService;
using OrderServiceTest.Buliders;

namespace OrderServiceTest
{
    public class OrderItemTest
    {
        [Fact]
        public void OrderItems_Should_Be_Created()
        {
            var orderItemBuilder = new OrderItemBuilder()
                .WithCount(1)
                .WithName("CD");

            var orderItem = orderItemBuilder.Build();

            Assert.Equal(1, orderItem.Count);
            Assert.Equal("CD", orderItem.Name);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        [InlineData(-5)]
        public void OrderItem_Should_Throw_Exteption_When_Item_Is_Less_Than_Zero_Or_More_Than_Three(int item)
        { 
            var orderItem = () => new OrderItem(item, "Book");

            orderItem.Should().Throw<OutOfRangeCountException>();
        }
    } 
}