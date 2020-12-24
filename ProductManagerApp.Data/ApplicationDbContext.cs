using ProductManagerApp.Entity;
using System.Data.Entity;

namespace ProductManagerApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductImagesEntity> ProductImages { get; set; }
        public DbSet<UsersEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }

    }
}
