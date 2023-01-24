using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class ShoppingListConfiguration : IEntityTypeConfiguration<ShoppingList>
    {
        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {

            builder.Property(pl => pl.Name).IsRequired().HasMaxLength(30);

            builder.HasMany(x => x.Products);

            builder.HasMany(x => x.Users)
                .WithOne();

        }
    }
}
