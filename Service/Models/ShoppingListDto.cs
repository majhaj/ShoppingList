using Domain.Entities;

namespace Application.Models
{
    public class ShoppingListDto
    {
        public string Name { get; set; }
        public List<Item> Items { get; set; }
    }
}
