﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Paging
{
    public static class QueryablePaginateExtensions
    {
        public static async Task<Paginate<T>> ToPaginateAsync<T>(
            this IQueryable<T> source,
            int index,
            int size,
            CancellationToken cancellation = default
            )
        {
            int count = await source.CountAsync(cancellation).ConfigureAwait(false);
            List<T> items = await source.Skip(index * size).Take(size).ToListAsync(cancellation).ConfigureAwait(false);
            Paginate<T> list = new()
            {
                Index = index,
                Count = count,
                Items = items,
                Size = size,
                Pages = (int)Math.Ceiling(count / (double)size)
            };

            return list;
        }

        public static Paginate<T> ToPaginate<T>(
            this IQueryable<T> source,
            int index,
            int size
            )
        {
            int count = source.Count();
            List<T> items = source.Skip(index * size).Take(size).ToList();
            Paginate<T> list = new()
            {
                Index = index,
                Count = count,
                Items = items,
                Size = size,
                Pages = (int)Math.Ceiling(count / (double)size)
            };

            return list;
        }
    }
}