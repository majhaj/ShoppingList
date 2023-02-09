using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ProductDto
    {
        public string? Name { get; set; }
        public Category Category { get; set; } = Category.Others;
        public string? MeasureUnit { get; set; }
    }
}
