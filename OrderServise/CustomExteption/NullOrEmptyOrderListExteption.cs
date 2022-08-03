
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.CustomExteption
{
    public class NullOrEmptyOrderListExteption:Exception
    {
        public override string Message => "The list cannot be empty or null ";
    }
}
