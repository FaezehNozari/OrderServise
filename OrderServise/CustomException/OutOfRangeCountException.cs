using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.CustomExteption
{
    public class OutOfRangeCountException : Exception
    {
        public override string Message => " Order should not be negative, zero or more than 3";
    }
}
