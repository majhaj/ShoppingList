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
        void AddProductToList(string productName, int id);
        ProductsListDto GetById(int id);
        void DeleteProduct(string productName, int id);
    }
}
