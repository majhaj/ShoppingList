using AutoMapper;
using Data.Entities;
using Data.Models;
using Repository.DbConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        private readonly ShoppingListDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductService(ShoppingListDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public int AddProduct(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return product.Id;
        }

        public void DeleteProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Id == id);
            if(product == null)
            {
                throw new Exception();
            }

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(ProductDto dto, int id)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Id == id);  
            if(product == null)
            {
                throw new Exception();
            }

            product.Name = dto.Name;
            product.Kcal = dto.Kcal;
            product.CategoryId = dto.CategoryId;

            _dbContext.SaveChanges();
        }
    }
}
