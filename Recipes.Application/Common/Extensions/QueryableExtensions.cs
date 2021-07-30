using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Application.Common.Extensions
{
    public static class QueryableExtensions
    {
        public static Task<PaginatedList<TDestination>> ToPaginatedListAsync<TDestination>(
            this IQueryable<TDestination> queryable,
            int pageNumber, 
            int itemsPerPage)
        {
            return PaginatedList<TDestination>.CreateAsync(queryable, pageNumber, itemsPerPage);
        }
    }
}
