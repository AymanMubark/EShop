using Microsoft.AspNetCore.Mvc;
using Catalog.API.DTOs;
using Catalog.API.Extensions;
using Catalog.API.IServices;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController : Controller
    {
        private readonly IProductService productService;

        public CatalogController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDTO>>  GetProductById(Guid id)
        {
            return await productService.GetProductById(id);
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<ProductResponseDTO>>> GetProducts([FromQuery] ProductSearchDTO model)
        {
            var result = await productService.GetProducts(model);
            Response.AddPaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);
            return result;
        }

    }
}

