using ShoppingList.Entities;

namespace ShoppingList.Models
{
    public class ProductsListDto
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
