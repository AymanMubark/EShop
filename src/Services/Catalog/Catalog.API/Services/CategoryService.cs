using System;
using AutoMapper;
using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore;
using Catalog.API.IServices;
using Catalog.API.Data;
using Catalog.API.DTOs;

namespace Catalog.API.Services
{
    public class CategoryService : ICategoryService
    {
        public readonly CatalogContext _db;
        public readonly IMapper _mapper;
        public CategoryService(CatalogContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<CategoryResponseDTO>> GetAllCategory(Guid? parentId)
        {

            var categories = await _db.Categories
                .Include(x=>x.SubCategories)
                .Where(e => e.ParentId == parentId) // <-- then apply the root filter
                .ToListAsync();

            return _mapper.Map<List<CategoryResponseDTO>>(categories);
        }
    }
}

