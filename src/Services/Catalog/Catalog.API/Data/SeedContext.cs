using AutoMapper;
using Catalog.API.DTOs;
using Catalog.API.Entites;
using Microsoft.EntityFrameworkCore;
using Nest;

namespace Catalog.API.Data
{
    public static class SeedContext
    {
        public static async Task initalApp(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<CatalogContext>();
            await context!.Database.MigrateAsync();

            //var elasticClient = services.GetRequiredService<IElasticClient>();
            //var mapper = services.GetRequiredService<IMapper>();

            //var products = await context.Products.Include(x => x.Category)
            //    .Include(x => x.ProductImages)
            //    .Include(x => x.ProductInformations)
            //    .Include(x => x.ProductChoices)
            //    .ThenInclude(x => x.Choice)
            //    .ThenInclude(x => x.ChoiceCategory)
            //    .AsNoTracking().ToListAsync();

            //foreach (var item in mapper.Map<List<ProductResponseDTO>>(products))
            //{
            //   var response = await elasticClient.IndexAsync<ProductResponseDTO>(item, x => x.Index("products"));
            //    Console.WriteLine(response.Id);
            //}

        }
    }
}