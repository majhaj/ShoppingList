using AutoMapper;
using Data.Entities;
using Data.Models;

namespace ShoppingList
{
    public class ShoppingListMappingProfile : Profile
    {
        public ShoppingListMappingProfile()
        {
            CreateMap<CreateListDto, ProductsList>();
            CreateMap<ProductsList, ProductsListDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
