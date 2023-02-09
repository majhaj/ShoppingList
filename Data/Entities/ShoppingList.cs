namespace Domain.Entities
{
    public class ShoppingList
    {
        private List<Item> _items = new List<Item>();

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Item> Items => _items;
        public int CreatorId { get; set; }
        public List<UserShoppingList> Users { get; set; }
    }
}
