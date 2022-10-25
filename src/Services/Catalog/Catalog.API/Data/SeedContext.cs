using Microsoft.EntityFrameworkCore;

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
        }
    }
}