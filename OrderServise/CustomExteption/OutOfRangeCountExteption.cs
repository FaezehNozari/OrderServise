using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.CustomExteption
{
    public class OutOfRangeCountExteption : Exception
    {
        public override string Message => " Order should not be negative, zero or more than 3";
    }
}
