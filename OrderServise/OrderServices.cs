using OrderService.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService
{
    public class OrderServices
    {

        private readonly IOrderRepository _orderRepository;
        private readonly ISmsService _smsService;

        public OrderServices(IOrderRepository orderRepository, ISmsService smsService)
        {
            _orderRepository = orderRepository;
            _smsService = smsService;
        }

        public void GetOrder(int id)
        {
            var orderRepository = _orderRepository.GetById(id);
            GuardIfOrderIdIsNull(orderRepository);
        }

        private static void GuardIfOrderIdIsNull(Order order)
        {
            if (order == null)
                throw new OrderNotRegisteredException();
        }

        public void ConfirmOrder()
        {
                _smsService.Send("Done!", "09368561354");
        }



    }
}
