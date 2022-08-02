using FluentAssertions;
using OrderServise.CustomExteption;
using Xunit;

namespace OrderServiceTest
{
    public class UnHappyOrderTest
    {
        [Fact]
        public void Should_Throw_When_Want_To_Delete_Item_From_Empty_List()
        {
            var order = new Order(12, orderItem: null);
            var result = () => order.DeleteItem(null);

            result.Should().Throw<DeleteItemExteption>();

        }

    }
}
