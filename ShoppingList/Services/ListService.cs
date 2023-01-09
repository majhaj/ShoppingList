using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingList.DbConfiguration;
using ShoppingList.Entities;
using ShoppingList.Models;

namespace ShoppingList.Services
{
    public interface IListService
    {
        int Create(CreateListDto dto);
        void Delete(int id);
        void AddProductToList(string productName, int id);
        ProductsListDto GetById(int id);
    }

    public class ListService : IListService
    {
        private readonly ShoppingListDbContext _dbContext;
        private readonly IMapper _mapper;

        public ListService(ShoppingListDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Create(CreateListDto dto)
        {
            var list = _mapper.Map<ProductsList>(dto);
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

        public void AddProductToList(string productName, int id)
        {
            var list = _dbContext.ProductsLists.FirstOrDefault(x => x.Id == id).Products;

            if (list == null)
            {
                throw new Exception();
            }

            var product = _dbContext.Products.FirstOrDefault(x => x.Name == productName);

            if(product == null)
            {
                product = new Product
                {
                    Name = productName,
                };
            }

            list.Add(product);
            
            _dbContext.SaveChanges();

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
