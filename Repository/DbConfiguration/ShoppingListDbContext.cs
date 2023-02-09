using Microsoft.EntityFrameworkCore;
using Data.Entities;

namespace Repository.DbConfiguration
{
    public class ShoppingListDbContext : DbContext
    {
        private string _connectionString = "Server=NOMED\\SQLEXPRESS;Database=ShoppingListDb;Encrypt=False;Trusted_Connection=True";

        public DbSet<User> Users { get; set; }
        public DbSet<ProductsList> ProductsLists { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(ue =>
            {
                ue.Property(u => u.FirstName).IsRequired().HasMaxLength(25);
                ue.Property(u => u.LastName).IsRequired().HasMaxLength(25);
                ue.Property(u => u.Birthday).IsRequired();
            });

            modelBuilder.Entity<ProductsList>(pe =>
            {
                pe.Property(pl => pl.Name).IsRequired().HasMaxLength(30);

                pe.HasOne(x => x.Creator)
                .WithMany(y => y.AllShoppingLists)
                .HasForeignKey(x => x.CreatorId);

                pe.HasMany(x => x.Products)
                    .WithMany(y => y.ProductsLists)
                    .UsingEntity<ProductsListProducts>(
                        x => x.HasOne(plp => plp.Product)
                            .WithMany()
                            .HasForeignKey(plp => plp.ProductId),
                        y => y.HasOne(plp => plp.ProductsList)
                            .WithMany()
                            .HasForeignKey(plp => plp.ProductsListId),
                        plp => plp.HasKey(x => new { x.ProductId, x.ProductsListId })
                    ) ;
            });

            modelBuilder.Entity<Product>(pe =>
            {
                pe.Property(p => p.Name).IsRequired().HasMaxLength(30);

                pe.HasOne(p => p.Creator)
                    .WithMany(p => p.History)
                    .HasForeignKey(p => p.CreatorId);

            });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
