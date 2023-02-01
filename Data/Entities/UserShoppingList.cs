using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class UserShoppingList
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public ShoppingList ShoppingList { get; set; }
        public int ShoppingListId { get; set; }

    }
}
