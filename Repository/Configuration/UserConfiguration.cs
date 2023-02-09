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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(25);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(25);
            builder.Property(u => u.Birthday).IsRequired();
            builder.Property(u => u.Email).IsRequired();

            builder.HasMany(x => x.ShoppingLists)
                .WithMany(y => y.Users)
                .UsingEntity<UserShoppingList>(
                    x => x.HasOne(y => y.ShoppingList)
                        .WithMany()
                        .HasForeignKey(y => y.ShoppingListId),
                    x => x.HasOne(y => y.User)
                        .WithMany()
                        .HasForeignKey(y => y.UserId),
                    y =>
                    {
                        y.HasKey(x => new { x.UserId, x.ShoppingListId });
                    }
                );

        }
    }
}
