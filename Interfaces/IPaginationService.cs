using ProvaPub.Models;

namespace ProvaPub.Interfaces
{
    public interface IPaginationService
    {
        public Pagination<T> GetPagedItems<T>(IQueryable<T> queryable, int page, int pageSize);
    }
}
