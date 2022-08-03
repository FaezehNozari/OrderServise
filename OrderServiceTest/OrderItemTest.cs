using Xunit;
using FluentAssertions;
using OrderServise.CustomExteption;

namespace OrderServiceTest
{
    public class OrderItemTest
    {
        [Fact]
        public void OrderItems_Should_Be_Created()
        {
            var orderItem = new OrderItem(2, "Pencil");

            Assert.Equal(2, orderItem.Count);
            Assert.Equal("Pencil", orderItem.Name);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        [InlineData(-5)]
        public void OrderItem_Should_Throw_Exteption_When_Count_Is_Less_Than_Zero_Or_More_Than_Three(int item)
        { 
            var orderItem = () => new OrderItem(item, "Book");

            orderItem.Should().Throw<OutOfRangeCountException>();
        }
    } 
}