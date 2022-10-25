using Catalog.API.DTOs;
using System;

namespace Catalog.API.IServices
{
    public interface ICategoryService
    {
        public Task<List<CategoryResponseDTO>> GetAllCategory(Guid?  parentId);
    }
}

