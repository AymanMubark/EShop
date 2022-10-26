using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public interface ICatalogService
    {
        public Task<IEnumerable<CatalogModel>> GetCatalog();
        public Task<IEnumerable<CatalogModel>> GetCategoriesByParent(string parentId);
        public Task<CatalogModel> GetCatalog(Guid id);
    }
}
