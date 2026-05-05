using Microsoft.EntityFrameworkCore;

namespace RecordShop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Record> Records { get; set; }
    }

}