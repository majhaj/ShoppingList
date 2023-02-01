using AutoMapper;
using Data.Entities;
using Data.Models;

namespace Web
{
    public class ShoppingListMappingProfile : Profile
    {
        public ShoppingListMappingProfile()
        {
            CreateMap<CreateListDto, ShoppingList>();
            CreateMap<ShoppingList, ShoppingListDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
