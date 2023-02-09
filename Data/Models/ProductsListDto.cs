using Data.Entities;

namespace Data.Models
{
    public class ProductsListDto
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
