using Domain.Entities;

namespace Domain.Models
{
    public class ShoppingListDto
    {
        public string Name { get; set; }
        public List<Item> Items { get; set; }
    }
}
