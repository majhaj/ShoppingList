using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products
{
    public interface IProductService
    {
        void UpdateProduct(int productId, Domain.Models.ProductDto dto);
        void AddProduct(Domain.Models.ProductDto dto);
        void DeleteProduct(int productId);
    }
}
