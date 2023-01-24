using Data.Entities;

namespace Data.Models
{
    public class ShoppingListDto
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
