using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.CustomExteption
{
    public class DeleteItemException : Exception
    {
        public override string Message => "It is not possible to delete";
    }
}
