using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Discount.API.Extensions
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

                command.CommandText = "DROP TABLE IF EXISTS Coupon;";
                await command.ExecuteNonQueryAsync(); 
                

                command.CommandText = @"CREATE TABLE Coupon(Id UUID NOT NULL DEFAULT uuid_generate_v1(),
                                                                CONSTRAINT Id_tbl PRIMARY KEY ( Id ), 
                                                                ProductName VARCHAR(24) NOT NULL,
                                                                Description TEXT,
                                                                Amount INT);";
                await command.ExecuteNonQueryAsync();

                command.CommandText = "INSERT INTO Coupon(ProductName, Description, Amount) VALUES('IPhone X', 'IPhone Discount', 150);";
                await command.ExecuteNonQueryAsync();

                command.CommandText = "INSERT INTO Coupon(ProductName, Description, Amount) VALUES('Samsung 10', 'Samsung Discount', 100);";
                await command.ExecuteNonQueryAsync();

            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }

    }
}
