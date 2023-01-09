namespace ShoppingList.Entities
{
    public class ProductsList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }
    }
}
