using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.CustomExteption
{
    public class CantChangeExteption:Exception
    {
        public override string Message  =>  "Cant Change Your State ";
    }
}
