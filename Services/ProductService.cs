using ProvaPub.Infrastructure;
using ProvaPub.Interfaces;
using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class ProductService: IProductService
    {
        private readonly IPaginationService _paginationService;
        private readonly TestDbContext _ctx;

        public ProductService(TestDbContext ctx, IPaginationService paginationService)
		{
            _ctx = ctx;
            _paginationService = paginationService;
        }

		public Pagination<Product> ListProducts(int page)
		{
            var queryable = _ctx.Products.AsQueryable();
            return _paginationService.GetPagedItems(queryable, page, pageSize:10);

        }

	}
}
