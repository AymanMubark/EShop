using System;
using System.Text.Json;
using Catalog.API.DTOs;

namespace Catalog.API.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, int currentPage,
            int itemsPerPage, long totalItems, long totalPages)
        {
            var paginationHeader = new PaginationHeaderDTO(currentPage, itemsPerPage, totalItems, totalPages);
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader, options));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}

