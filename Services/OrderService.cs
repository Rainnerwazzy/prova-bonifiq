using ProvaPub.Interfaces;
using ProvaPub.Models;

namespace ProvaPub.Services
{
	public class OrderService: IOrderService
    {
        private readonly IPaymentFactory _paymentFactory;

        public OrderService(IPaymentFactory paymentFactory)
        {
            _paymentFactory = paymentFactory;
        }

        public async Task<Order> PayOrderAsync(string paymentMethod, decimal paymentValue, int customerId)
        {           
            IPaymentStrategy paymentStrategy = _paymentFactory.CreatePaymentStrategy(paymentMethod);

            return await paymentStrategy.ProcessPaymentAsync(paymentValue, customerId);
        }
    }
}
