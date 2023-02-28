using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class OpenFoodFactsProduct
    {
        public string Status { get; set; }
        public OpenFoodFactsProductData Product { get; set; }
    }

    public class OpenFoodFactsProductData
    {
        public string Code { get; set; }
        public string ProductName { get; set; }
        public string NutritionGrade { get; set; }

    }
}
