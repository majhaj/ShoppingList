using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class UserShoppingListConfiguration : IEntityTypeConfiguration<UserShoppingList>
    {
        public void Configure(EntityTypeBuilder<UserShoppingList> builder)
        {
            builder.HasKey(x => new { x.UserId, x.ShoppingListId });

            builder.HasOne(usl => usl.User)
                .WithMany(usl => usl.ShoppingLists)
                .HasForeignKey(usl => usl.UserId);

            builder.HasOne(usl => usl.ShoppingList)
                .WithMany(usl => usl.Users)
                .HasForeignKey(usl => usl.ShoppingListId);
        }
    }
}
