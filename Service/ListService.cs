using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Data.Entities;
using Data.Models;
using Repository.DbConfiguration;
using System.Linq.Expressions;

namespace Service
{
    public class ListService : IListService
    {
        private readonly ShoppingListDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;

        public ListService(ShoppingListDbContext dbContext, IMapper mapper, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userContextService = userContextService;
        }

        public int Create(CreateListDto dto)
        {
            var list = _mapper.Map<ProductsList>(dto);
            //list.CreatorId = _userContextService.GetUserId;

            //var history = _dbContext.Users.FirstOrDefault(x => x.Id == list.CreatorId).History;

            _dbContext.Add(list);

            _dbContext.SaveChanges();

            return list.Id;
            
        }

        public void Delete(int id)
        {
            var list = _dbContext.ProductsLists.FirstOrDefault(x => x.Id == id);

            _dbContext.ProductsLists.Remove(list);

            _dbContext.SaveChanges();
        }

        public void AddProductToList(ProductDto dto, int listId)
        {
            var list = _dbContext.ProductsLists.FirstOrDefault(x => x.Id == listId);
            if(list == null)
            {
                throw new Exception();
            }

            var product = _mapper.Map<Product>(dto);

            list.Products.Add(product);
            
            _dbContext.SaveChanges();

        }

        public void DeleteProduct(int productId, int listId)
        {
            var list = _dbContext.ProductsLists.FirstOrDefault(x => x.Id == listId);
            if(list ==null)
            {
                throw new Exception();
            }

            var item = list.Products.FirstOrDefault(x => x.Id == productId);
            if(item == null)
            {
                throw new Exception();
            }

            list.Products.Remove(item);
        }

        public ProductsListDto GetById(int id)
        {
            var list = _dbContext.ProductsLists.FirstOrDefault(x => x.Id == id);
            if(list == null)
            {
                throw new Exception();
            }

            var result = _mapper.Map<ProductsListDto>(list);
            return result;
        }
    }
}
