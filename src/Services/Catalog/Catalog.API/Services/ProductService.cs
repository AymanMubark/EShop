using AutoMapper;
using AutoMapper.QueryableExtensions;
using Catalog.API.Data;
using Catalog.API.DTOs;
using Catalog.API.Entites;
using Catalog.API.IServices;
using Microsoft.EntityFrameworkCore;
using Nest;

namespace Catalog.API.Services
{
    public class ProductService : IProductService
    {
        public readonly CatalogContext _db;
        public readonly IMapper _mapper;
        public readonly IElasticClient _elasticClient;
        public ProductService(CatalogContext db, IMapper mapper, IElasticClient elasticClient)
        {
            _db = db;
            _mapper = mapper;
            _elasticClient = elasticClient;
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

            //var query = _db.Products
            //                     .AsQueryable();

            //if (model.CategoryId != null)
            //{
            //    var catgeoriesId = await _db.Categories.Where(x => x.ParentId == model.CategoryId).Select(x => x.Id).ToListAsync();
            //    if (catgeoriesId.Count() > 0)
            //    {
            //        query = query.Where(x => catgeoriesId.Contains(x.CategoryId!.Value));
            //    }
            //    else
            //    {
            //        query = query.Where(x => x.CategoryId == model.CategoryId);
            //    }
            //}

            //if (model.MinPrice != null && model.MaxPrice != null)
            //{
            //    query = query.Where(x => x.Price >= model.MinPrice && x.Price <= model.MaxPrice);
            //}
            //if (model.ChoicesId != null)
            //{
            //    if (model.ChoicesId.Count() > 0)
            //    {
            //        List<Guid> ids = model.ChoicesId.Split(",").Select(x => Guid.Parse(x)).ToList();
            //        query = query.Where(x => x.ProductChoices != null && x.ProductChoices.Any(y => ids.Contains(y.Choice.Id)));
            //    }
            //}
            //query = query.Where(x =>
            //                     (string.IsNullOrWhiteSpace(model.SearchKey) ||
            //                     x.Name.ToLower().Contains(model.SearchKey.ToLower()) ||
            //                     x.Description.ToLower().Contains(model.SearchKey.ToLower()) ||
            //                     x.FullDescription.ToLower().Contains(model.SearchKey.ToLower()) ||
            //                     x.Category!.Name.ToLower().Contains(model.SearchKey.ToLower())
            //        ));
            //if (!string.IsNullOrWhiteSpace(model.SortBy))
            //{

            //    switch (model.SortBy)
            //    {
            //        case "PriceLowToHigh":
            //            query = query.OrderBy(x => x.Price);
            //            break;
            //        case "PriceHighToLow":
            //            query = query.OrderByDescending(x => x.Price);
            //            break;
            //        case "NewArrivals":
            //            query = query.OrderByDescending(x => x.CreatedDate);
            //            break;
            //        case "Rating":
            //            break;
            //    }
            //}

            var sortDescriptor =  new SortDescriptor<ProductResponseDTO>();
            string[] ids = {};
            if (model.ChoicesId != null)
            {
                if (model.ChoicesId.Count() > 0)
                {
                    ids = model.ChoicesId.Split(",");
                }
            }
            switch (model.SortBy)
            {
                case "PriceLowToHigh":
                    sortDescriptor = sortDescriptor.Ascending(x => x.Price);
                    break;
                case "PriceHighToLow":
                    sortDescriptor = sortDescriptor.Descending(x => x.Price);
                    break;
                case "NewArrivals":
                    sortDescriptor = sortDescriptor.Descending(x => x.CreatedDate);
                    break;
                case "Rating":
                    break;
            }
        

        var response = await _elasticClient.SearchAsync<ProductResponseDTO>(s => s.Index("products")
        .From((model.PageNumber - 1) * model.PageSize)
        .Size(model.PageSize)
        .Sort(s=> sortDescriptor)
        .Query(q =>q.MultiMatch(m=> m.Fields(f=>f.Field(p=> p.Name).Fields(p=> p.Description).Field(p=>p.FullDescription).Field(p=>p.Category!.Name)).Query(model.SearchKey).Type(TextQueryType.Phrase))
           && q.Terms(m => m
            .Field(f => f.ProductChoices.First().Choice.Id)
            .Terms(ids.First()))
        && q.Range(r=>r.Field(f => f.Price).LessThan(model.MaxPrice).GreaterThanOrEquals(model.MinPrice))
        && q.MatchPhrase(m=> m.Field(f=>f.Category!.Id).Query(model.CategoryId.ToString()))
     
        ));

            return new PagedList<ProductResponseDTO>(response.Documents, response.Total, model.PageNumber, model.PageSize);
        }
    }
}

