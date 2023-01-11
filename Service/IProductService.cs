using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IProductService
    {
        int AddProduct(ProductDto dto);
        void DeleteProduct(int id);
        void UpdateProduct(ProductDto dto, int id);
    }
}
