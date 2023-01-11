using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ProductDto
    {
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public int? Kcal { get; set; }
    }
}
