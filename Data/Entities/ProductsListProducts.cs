using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ProductsListProducts
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public ProductsList ProductsList { get; set; }
        public int ProductsListId { get; set; }
    }
}
