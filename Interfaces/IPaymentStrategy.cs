using ProvaPub.Models;

namespace ProvaPub.Interfaces
{
    public interface IPaymentStrategy
    {
        public Task<Order> ProcessPaymentAsync(decimal paymentValue, int customerId);
    }
}
