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
        public DbSet<Category> Categories { get; set; }

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
            });

            modelBuilder.Entity<Product>(pe =>
            {
                pe.Property(p => p.Name).IsRequired().HasMaxLength(30);
                pe.Property(p => p.CategoryId).IsRequired();

                pe.HasOne(x => x.Category)
                .WithMany(y => y.Products)
                .HasForeignKey(x => x.CategoryId);

            });

            modelBuilder.Entity<Category>()
                .Property(c => c.Name).IsRequired().HasMaxLength(30);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
