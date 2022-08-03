using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.CustomExteption
{
    public class CantDeleteItemExteption:Exception
    {
        public override string Message => "Can Not Delete This Item";
    }
}
