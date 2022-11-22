using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Ordering.Infrastructure.Persistence;
using Polly;
using SendGrid.Helpers.Mail;

namespace Ordering.API.Extensions
{
    public static class HostExtensions
    {
        public static async Task initalApp(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<OrderContext>>();
            var context = services.GetRequiredService<OrderContext>();
            try
            {
                logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(OrderContext).Name);

                var retry = Policy.Handle<SqlException>()
                    .WaitAndRetry(
                        retryCount: 5,
                        sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                        onRetry: (exception, retryCount, context) =>
                        {
                            logger.LogError($"Retry {retryCount} of {context.PolicyKey} at {context.OperationKey}, due to: {exception}.");
                        });
                retry.Execute(() => context.Database.Migrate());

                logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(OrderContext).Name);

            }
            catch (SqlException ex)
            {
                logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(OrderContext).Name);
            }

        }
    }
}
