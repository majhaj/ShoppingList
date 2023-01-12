using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IListService
    {
        int Create(CreateListDto dto);
        void Delete(int id);
        void AddProductToList(ProductDto dto, int listId);
        ProductsListDto GetById(int id);
        void DeleteProduct(int productId, int listId);
    }
}
