﻿using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Configuration;

namespace Infrastructure
{
    public class ShoppingListDbContext : DbContext
    {
        private string _connectionString = "Server=NOMED\\SQLEXPRESS;Database=ShoppingListDb;Encrypt=False;Trusted_Connection=True";

        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<UserShoppingList> UserShoppingLists { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ShoppingListConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new UserShoppingListConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
