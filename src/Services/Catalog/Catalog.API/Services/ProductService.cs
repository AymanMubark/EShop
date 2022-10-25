using AutoMapper;
using AutoMapper.QueryableExtensions;
using Catalog.API.Data;
using Catalog.API.DTOs;
using Catalog.API.Entites;
using Catalog.API.IServices;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Services
{
    public class ProductService : IProductService
    {
        public readonly CatalogContext _db;
        public readonly IMapper _mapper;
        public ProductService(CatalogContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductResponseDTO> GetProductById(Guid id)
        {
            Product? product = await _db.Products.Include(x => x.Category)
                .Include(x => x.ProductImages)
                .Include(x => x.ProductInformations)
                .Include(x => x.ProductChoices)
                .ThenInclude(x => x.Choice)
                .ThenInclude(x => x.ChoiceCategory)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException("product not exist");
            }
            return _mapper.Map<ProductResponseDTO>(product);
        }

        public async Task<PagedList<ProductResponseDTO>> GetProducts(ProductSearchDTO model)
        {
            
            var query =  _db.Products
                                 .AsQueryable();

            if (model.CategoryId != null)
            {
                var catgeoriesId = await   _db.Categories.Where(x => x.ParentId == model.CategoryId).Select(x => x.Id).ToListAsync();
                if(catgeoriesId.Count() > 0)
                {
                    query = query.Where(x => catgeoriesId.Contains(x.CategoryId!.Value));
                }
                else
                {
                    query = query.Where(x => x.CategoryId  == model.CategoryId);
                }
            }

            if(model.MinPrice != null && model.MaxPrice != null)
            {
                query = query.Where(x => x.Price >= model.MinPrice && x.Price <= model.MaxPrice);
            }
            if (model.ChoicesId != null)
            {
                if(model.ChoicesId.Count() > 0)
                {
                    List<Guid> ids = model.ChoicesId.Split(",").Select(x => Guid.Parse(x)).ToList();
                    query = query.Where(x => x.ProductChoices != null && x.ProductChoices.Any(y => ids.Contains(y.Choice.Id)));
                }
            }
            query = query.Where(x =>
                                 (string.IsNullOrWhiteSpace(model.SearchKey) ||
                                 x.Name.ToLower().Contains(model.SearchKey.ToLower()) ||
                                 x.Description.ToLower().Contains(model.SearchKey.ToLower()) ||
                                 x.FullDescription.ToLower().Contains(model.SearchKey.ToLower()) ||
                                 x.Category!.Name.ToLower().Contains(model.SearchKey.ToLower())
                    ));
            if (!string.IsNullOrWhiteSpace(model.SortBy))
            {
                
                switch (model.SortBy)
                {
                    case "PriceLowToHigh":
                        query = query.OrderBy(x => x.Price);
                        break;
                    case "PriceHighToLow":
                        query = query.OrderByDescending(x => x.Price);
                        break;
                    case "NewArrivals":
                        query = query.OrderByDescending(x => x.CreatedDate);
                        break;
                    case "Rating":
                        break;
                }
            }
    
            return await PagedList<ProductResponseDTO>.CreateAsync(query
              .ProjectTo<ProductResponseDTO>(_mapper.ConfigurationProvider)
              .AsNoTracking(), model.PageNumber, model.PageSize);
        }
    }
}

