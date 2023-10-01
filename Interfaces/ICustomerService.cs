using ProvaPub.Models;

namespace ProvaPub.Interfaces
{
    public interface ICustomerService
    {
        public Pagination<Customer> ListCustomers(int page);
        public Task<bool> CanPurchaseAsync(int customerId, decimal purchaseValue);
    }
}
