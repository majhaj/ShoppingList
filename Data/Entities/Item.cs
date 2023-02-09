using Domain.Enums;

namespace Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double Quantity { get; set; }
        public int Position { get; set; }

        //public string Name { get; set; }
        //public Category Category { get; set; } = Category.Others;
    }
}
