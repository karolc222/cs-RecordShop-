using Microsoft.EntityFrameworkCore;
using RecordShop.Models;

namespace RecordShop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }        
        
        public DbSet<Album> Albums { get; set; }
    }
}