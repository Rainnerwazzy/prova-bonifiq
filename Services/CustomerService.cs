using Microsoft.EntityFrameworkCore;
using ProvaPub.Infrastructure;
using ProvaPub.Interfaces;
using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly IPaginationService _paginationService;
        private readonly TestDbContext _ctx;

        public CustomerService(TestDbContext ctx, IPaginationService paginationService)
        {
            _ctx = ctx;
            _paginationService = paginationService;
        }

        public async Task<bool> CanPurchaseAsync(int customerId, decimal purchaseValue)
        {
            if (customerId <= 0) 
            { 
                throw new ArgumentOutOfRangeException(nameof(customerId)); 
            }

            if (purchaseValue <= 0) 
            { 
                throw new ArgumentOutOfRangeException(nameof(purchaseValue)); 
            }
      
            var customer = await _ctx.Customers.FindAsync(customerId) ?? throw new InvalidOperationException($"Customer Id {customerId} does not exists");
         
            var baseDate = DateTime.UtcNow.AddMonths(-1);
            var ordersInThisMonth = await _ctx.Orders.CountAsync(s => s.CustomerId == customerId && s.OrderDate >= baseDate);
            
            if (ordersInThisMonth > 0)
            {
                return false;
            }
           
            var haveBoughtBefore = await _ctx.Customers.CountAsync(s => s.Id == customerId && s.Orders.Any());
           
            if (haveBoughtBefore == 0 && purchaseValue > 100)
            {
                return false;
            }

            return true;
        }

        public Pagination<Customer> ListCustomers(int page)
        {
            var queryable = _ctx.Customers.AsQueryable();
            return _paginationService.GetPagedItems(queryable, page, pageSize:10);

        }
    }
}
