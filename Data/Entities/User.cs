namespace Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }

        public List<ShoppingList> ShoppingLists { get; set; }
        public List<Product> History { get; set; }

    }
}
