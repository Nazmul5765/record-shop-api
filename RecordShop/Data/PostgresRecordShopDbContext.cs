using Microsoft.EntityFrameworkCore;

namespace RecordShop.Data
{
    public class PostgresRecordShopDbContext : RecordShopDbContext
    {
        public PostgresRecordShopDbContext(
            DbContextOptions<PostgresRecordShopDbContext> options)
            : base(options)
        {
        }
    }
}
