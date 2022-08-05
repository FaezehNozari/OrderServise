using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.CustomException
{
    public class NullOrderItemException: Exception
    {
        public override string Message => "OrderItem Can Not Be Null ";
    }
}
