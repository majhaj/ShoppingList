using Data.Enums;

namespace Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; } = Category.Others;
        public User Creator { get; set; }
        public int CreatorId { get; set; }

        public List<ShoppingList> ShoppingLists { get; set; }
    }
}
