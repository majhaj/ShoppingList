namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public List<UserShoppingList> ShoppingLists { get; set; }
        public List<Item> History { get; set; }

    }
}
