using ERPSystem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPSystem.API.Contexts
{
    public class TemporaryContext: DbContext
    {

        public DbSet<Product> Products { get; set; }

        public TemporaryContext(DbContextOptions<TemporaryContext> options)
    : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Products");
        }
    }
}
