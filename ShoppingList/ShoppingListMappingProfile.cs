using AutoMapper;
using ShoppingList.Entities;
using ShoppingList.Models;

namespace ShoppingList
{
    public class ShoppingListMappingProfile : Profile
    {
        public ShoppingListMappingProfile()
        {
            CreateMap<CreateListDto, ProductsList>();
            CreateMap<ProductsList, ProductsListDto>();
        }
    }
}
