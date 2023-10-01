using ProvaPub.Models;

namespace ProvaPub.Interfaces
{
    public interface IProductService
    {
        public Pagination<Product> ListProducts(int page);
    }
}
