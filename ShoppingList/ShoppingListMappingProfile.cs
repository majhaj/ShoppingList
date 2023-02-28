using AutoMapper;
using Domain.Entities;
using Application.Models;
using Application.OpenFoodProducts;

namespace API
{
    public class ShoppingListMappingProfile : Profile
    {
        public ShoppingListMappingProfile()
        {
            CreateMap<CreateListDto, ShoppingList>();
            CreateMap<ShoppingList, ShoppingListDto>();
            CreateMap<ItemDto, Item>();
            CreateMap<CreateUserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<OpenFoodFactsProduct, ProductDto>();
        }
    }
}
