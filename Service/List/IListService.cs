using Domain.Entities;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.List
{
    public interface IListService
    {
        int CreateList(CreateListDto dto);
        void DeleteList(int id);
        void AddItemToList(ItemDto dto, int listId);
        ShoppingListDto GetListById(int id);
        void DeleteItem(int productId, int listId);
        void ShareList(int listId, int userId);
    }
}
