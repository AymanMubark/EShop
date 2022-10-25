using Catalog.API.DTOs;

namespace Catalog.API.IServices
{
    public interface IProductService
    {
        public Task<PagedList<ProductResponseDTO>> GetProducts(ProductSearchDTO model);
        public Task<ProductResponseDTO> GetProductById(Guid id);
    }
}

