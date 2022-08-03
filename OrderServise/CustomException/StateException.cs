
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.CustomExteption
{
    public class StateException : Exception
    {
        public override string Message => "Change State ";
    }
}
