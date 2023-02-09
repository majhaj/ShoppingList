using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class UserShoppingListConfiguration : IEntityTypeConfiguration<UserShoppingList>
    {
        public void Configure(EntityTypeBuilder<UserShoppingList> builder)
        {
            builder.HasKey(x => new { x.UserId, x.ShoppingListId });
        }
    }
}
