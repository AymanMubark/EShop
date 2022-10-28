using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Catalog.API.Data;
using Catalog.API.Helpers;
using Catalog.API.Mapper;
using Catalog.API.IServices;
using Catalog.API.Services;

namespace Catalog.API.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddAutoMapper(typeof(MapperProfile).Assembly);

            services.AddDbContext<CatalogContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("CatalogConnectionString"));
                option.EnableDetailedErrors();
                option.EnableSensitiveDataLogging();
            });

            return services;
        }
    }
}
