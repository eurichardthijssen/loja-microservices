using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.ProductAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(){}

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) {}

        public DbSet<Product> Products { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Lapis",
                Price = new decimal(29.9),
                Description = "Melhor lapis que existe",
                ImageURL = "https://http2.mlstatic.com/D_NQ_NP_971577-MLB44653901933_012021-O.webp",
                CategoryName = "Lapis"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Lapis 4",
                Price = new decimal(29.9),
                Description = "Melhor lapis que existe 4",
                ImageURL = "https://http2.mlstatic.com/D_NQ_NP_971577-MLB44653901933_012021-O.webp",
                CategoryName = "Lapis"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Lapis 5",
                Price = new decimal(39.9),
                Description = "Melhor lapis que existe 5",
                ImageURL = "https://http2.mlstatic.com/D_NQ_NP_971577-MLB44653901933_012021-O.webp",
                CategoryName = "Lapis"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Name = "Lapis 6",
                Price = new decimal(49.9),
                Description = "Melhor lapis que existe 6",
                ImageURL = "https://http2.mlstatic.com/D_NQ_NP_971577-MLB44653901933_012021-O.webp",
                CategoryName = "Lapis"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 7,
                Name = "Lapis 7",
                Price = new decimal(59.9),
                Description = "Melhor lapis que existe 7",
                ImageURL = "https://http2.mlstatic.com/D_NQ_NP_971577-MLB44653901933_012021-O.webp",
                CategoryName = "Lapis"
            });
        }
    }
}
