using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Application.Common
{
    public class PaginatedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, long totalItems, int currentPage, int itemsPerPage)
        {
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(totalItems / (double)itemsPerPage);
            this.AddRange(items);
        }

        public bool HasPreviousPage => CurrentPage > 1;

        public bool HasNextPage => CurrentPage < TotalPages;

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int currentPage, int itemsPerPage)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((currentPage - 1) * itemsPerPage).Take(itemsPerPage).ToListAsync();
            
            return new PaginatedList<T>(items, count, currentPage, itemsPerPage);
        }

        public static async Task<PaginatedList<T>> CreateAsync(IFindFluent<T, T> source, int currentPage, int itemsPerPage)
        {
            var count = await source.CountDocumentsAsync();
            var items = await source.Skip((currentPage - 1) * itemsPerPage).Limit(itemsPerPage).ToListAsync();

            return new PaginatedList<T>(items, count, currentPage, itemsPerPage);
        }
    }
}
