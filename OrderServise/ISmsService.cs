using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService
{
    public interface ISmsService
    {
        void Send(string message, string phoneNumber);
    }
}
