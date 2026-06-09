using System.Data.Entity;

namespace SwaggerCRUD.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DemoAPI")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}