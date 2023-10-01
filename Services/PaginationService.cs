using ProvaPub.Interfaces;
using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class PaginationService : IPaginationService
    {
        public Pagination<T> GetPagedItems<T>(IQueryable<T> queryable, int page, int pageSize)
        {
            
            if (page < 1)
            {
                page = 1;
            }

            // Calcula o índice inicial com base no número da página e tamanho da página.
            int startIndex = (page - 1) * pageSize;

            // Obtém os clientes do banco de dados, considerando a página e o tamanho da página.
            var items = queryable.Skip(startIndex).Take(pageSize).ToList();

            // Verifica se há mais páginas após a página atual.
            bool hasNext = (startIndex + pageSize) < queryable.Count();


            return new Pagination<T>()
            {
                HasNext = hasNext,
                TotalCount = queryable.Count(),
                Items = items
            };
        }
    }
}
