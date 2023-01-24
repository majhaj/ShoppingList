namespace Data.Entities
{
    public class ShoppingList
    {
        private List<Product> _products = new List<Product>();

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products => _products;
        public List<UserShoppingList> Users { get; set; }
    }
}
