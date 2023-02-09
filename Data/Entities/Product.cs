using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; } = Category.Others;
        public User Creator { get; set; }
        public int CreatorId { get; set; }

        public List<ProductsList> ProductsLists { get; set; }
    }
}
