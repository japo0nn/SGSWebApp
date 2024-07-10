﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGSWebApp.Application.Common.Models
{
    public class PageViewModel<T> where T : class
    {
        public IReadOnlyCollection<T> Items { get; set; }
        public int PageNumber { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }

        public PageViewModel(IReadOnlyCollection<T> items, int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            Items = items;
        }

        public PageViewModel(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
        }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;

        public static async Task<PageViewModel<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PageViewModel<T>(items, count, pageNumber, pageSize);
        }
    }
}
