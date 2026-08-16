using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace RecordShop.Data
{
    public class PostgresRecordShopDbContextFactory
        : IDesignTimeDbContextFactory<PostgresRecordShopDbContext>
    {
        public PostgresRecordShopDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.Production.json", optional: true)
                .AddUserSecrets<Program>()
                .Build();

            var connectionString =
                configuration.GetConnectionString("PostgresConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    "PostgresConnection connection string was not found.");
            }

            var optionsBuilder =
                new DbContextOptionsBuilder<PostgresRecordShopDbContext>();

            optionsBuilder.UseNpgsql(connectionString);

            return new PostgresRecordShopDbContext(optionsBuilder.Options);
        }
    }
}
