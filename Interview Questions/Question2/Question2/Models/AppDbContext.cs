using Microsoft.EntityFrameworkCore;

namespace Question2.Models
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options) { 
        }
        public DbSet<Person>Persons { get; set; }
    }
}
