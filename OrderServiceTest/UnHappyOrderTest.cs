using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using OrderServise.CustomExteption;

namespace OrderServiceTest
{
    public class UnHappyOrderTest
    {
      
        public void Should_Throw_When_Want_To_Delete_Item_From_Empty_List()
        {
            var list = new List<OrderItems>() is null;
            var result = () => new Order(12,list);

            result.Should().Throw<DeleteItemExteption>();
        }



    }
}
