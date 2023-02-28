using Application.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products
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
        public void AddProduct(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);

            if(_dbContext.Products.Any(x => x.Name == product.Name))
            {
                throw new DuplicateNameException(product.Name);
            }

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Id == productId);
            if(product == null)
            {
                throw new ProductNotFoundException(productId);
            }
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();

        }

        public void UpdateProduct(int productId, ProductDto dto)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Id == productId);
            if (product == null)
            {
                throw new ProductNotFoundException(productId);
            }

            product.MeasureUnit = dto.MeasureUnit;
            product.Category = dto.Category;

            _dbContext.SaveChanges();
        }
    }
}
