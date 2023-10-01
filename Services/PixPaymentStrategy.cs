using ProvaPub.Interfaces;
using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class PixPaymentStrategy : IPaymentStrategy
    {
        public Task<Order> ProcessPaymentAsync(decimal paymentValue, int customerId)
        {
            return Task.FromResult(new Order()
            {
                Value = paymentValue
            });
        }
    }
}
