﻿using Microsoft.EntityFrameworkCore;
using Data.Entities;
using Repository.Configuration;

namespace Repository
{
    public class ShoppingListDbContext : DbContext
    {
        private string _connectionString = "Server=NOMED\\SQLEXPRESS;Database=ShoppingListDb;Encrypt=False;Trusted_Connection=True";

        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserShoppingList> UserShoppingLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ShoppingListConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserShoppingListConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}