using System;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.DTOs
{

        public class PagedList<T> : List<T>
        {
            public PagedList(IEnumerable<T> items, long count, int pageNumber, int pageSize)
            {
                CurrentPage = pageNumber;
                TotalPages = (long)Math.Ceiling(count / (double)pageSize);
                PageSize = pageSize;
                TotalCount = count;
                AddRange(items);
            }

            public int CurrentPage { get; set; }
            public long TotalPages { get; set; }
            public int PageSize { get; set; }
            public long TotalCount { get; set; }

        }
    }
		

