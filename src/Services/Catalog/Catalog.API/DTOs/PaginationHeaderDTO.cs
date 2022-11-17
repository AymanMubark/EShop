using System;
namespace Catalog.API.DTOs
{
    public class PaginationHeaderDTO
    {
        public PaginationHeaderDTO(int currentPage, int itemsPerPage, long totalItems, long totalPages)
        {
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
            TotalPages = totalPages;
        }

        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public long TotalItems { get; set; }
        public long TotalPages { get; set; }
    }
}

