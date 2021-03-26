using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

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

        public static Task<PaginatedList<TDestination>> ToPaginatedListAsync<TDestination>(
           this IFindFluent<TDestination, TDestination> source,
           int pageNumber,
           int itemsPerPage)
        {
            return PaginatedList<TDestination>.CreateAsync(source, pageNumber, itemsPerPage);
        }
    }
}
