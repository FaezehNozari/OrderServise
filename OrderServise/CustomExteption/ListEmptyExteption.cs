
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.CustomExteption
{
    public class ListEmptyExteption:Exception
    {
        public override string Message => "List is Empty";
    }
}
