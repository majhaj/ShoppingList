using AutoMapper;
using Data.Entities;
using Data.Models;

namespace Service
{
    public class ShoppingListMappingProfile : Profile
    {
        public ShoppingListMappingProfile()
        {
            CreateMap<CreateListDto, ProductsList>();
            CreateMap<ProductsList, ProductsListDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
