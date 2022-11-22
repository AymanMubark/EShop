using Microsoft.Extensions.Configuration;
using Npgsql;
using Polly;

namespace Discount.Grpc.Extensions
{
    public static class HostExtensions
    {
        public static  void initalApp(this WebApplication app)
        {
            try
            {
                using var scope = app.Services.CreateScope();
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<WebApplication>>();

                logger.LogInformation("Migrating postresql database.");

                var retry = Policy.Handle<NpgsqlException>()
                    .WaitAndRetry(
                        retryCount: 5,
                        sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), // 2,4,8,16,32 sc
                        onRetry: (exception, retryCount, context) =>
                        {
                            logger.LogError($"Retry {retryCount} of {context.PolicyKey} at {context.OperationKey}, due to: {exception}.");
                        });

                retry.Execute(() =>
                {
                    using var connection = new NpgsqlConnection
                    (app.Configuration.GetValue<string>("ConnectionStrings:ConnectionString"));
                    connection.Open();

                    using var command = new NpgsqlCommand
                    {
                        Connection = connection
                    };

                    command.CommandText = "DROP TABLE IF EXISTS Coupon";
                    command.ExecuteNonQuery();

                    command.CommandText = @"CREATE TABLE Coupon(Id UUID NOT NULL DEFAULT uuid_generate_v1(),
                                                                CONSTRAINT Id_tbl PRIMARY KEY ( Id ), 
                                                                ProductName VARCHAR(24) NOT NULL,
                                                                Description TEXT,
                                                                Amount INT);";
                    command.ExecuteNonQuery();


                });

                logger.LogInformation("Migrated postresql database.");


            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }

    }
}
