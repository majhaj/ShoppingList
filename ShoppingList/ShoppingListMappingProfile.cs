using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace API
{
    public class ShoppingListMappingProfile : Profile
    {
        public ShoppingListMappingProfile()
        {
            CreateMap<CreateListDto, ShoppingList>();
            CreateMap<ShoppingList, ShoppingListDto>();
            CreateMap<ItemDto, Item>();
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
