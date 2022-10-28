using Npgsql;

namespace Discount.Grpc.Extensions
{
    public static class HostExtensions
    {
        public static async Task initalApp(this WebApplication app)
        {
            try
            {

                using var connection = new NpgsqlConnection
                    (app.Configuration.GetValue<string>("ConnectionStrings:ConnectionString"));
                connection.Open();

                using var command = new NpgsqlCommand
                {
                    Connection = connection
                };
                //command.CommandText = "CREATE EXTENSION IF NOT EXISTS \"uuid-ossp\";";
                //await command.ExecuteNonQueryAsync();
                command.CommandText = @"DROP TABLE IF EXISTS Coupon;";
                await command.ExecuteNonQueryAsync(); 
                

                command.CommandText = @"CREATE TABLE Coupon(Id UUID NOT NULL DEFAULT uuid_generate_v1(),
                                                                CONSTRAINT Id_tbl PRIMARY KEY ( Id ), 
                                                                ProductName VARCHAR(24) NOT NULL,
                                                                Description TEXT,
                                                                Amount INT);";
                await command.ExecuteNonQueryAsync();

            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }

    }
}
