using ProvaPub.Models;

namespace ProvaPub.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> PayOrderAsync(string paymentMethod, decimal paymentValue, int customerId);
    }
}
