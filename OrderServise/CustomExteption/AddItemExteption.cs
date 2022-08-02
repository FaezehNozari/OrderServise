using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.CustomExteption
{
    public class AddItemExteption: Exception
    {
        public override string Message => "It is not possible to Add ";
    }
}
