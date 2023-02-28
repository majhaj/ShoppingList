using Application.Models;
using Application.Products;
using AutoMapper;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OpenFoodProducts
{
    public class OpenFoodProductService : IOpenFoodProductService
    {
        private readonly IOpenFoodProductService _apiClient;
        private readonly ShoppingListDbContext _dbContext;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public OpenFoodProductService(ShoppingListDbContext dbContext, IProductService productService, IMapper mapper)
        {
            _apiClient = RestClient.For<IOpenFoodProductService>("https://majhaj:123maja@world.openfoodfacts.net");
            _dbContext = dbContext;
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<OpenFoodFactsProduct> GetProductAsync(string barcode)
        {
            var product = await _apiClient.GetProductAsync(barcode);

            return product;

        }

        public async Task<List<OpenFoodFactsProduct>> SearchProductsAsync
            (
            string tagtype0,
            string tagContains0,
            string tag0,
            string tagtype1,
            string tagContains1,
            string tag1,
            string tagtype2,
            string tagContains2,
            string tag2,
            string tagtype3,
            string tagContains3,
            string tag3,
            string action = "procces"
            )
        {
            var products = await _apiClient.SearchProductsAsync(
                tagtype0, tagContains0, tag0,
                tagtype1, tagContains1, tag1,
                tagtype2, tagContains2, tag2,
                tagtype3, tagContains3, tag3,
                action
            );

            return products;
        }

        public async Task SaveProductAsync(string barcode)
        {
            var product = await _apiClient.GetProductAsync(barcode);

            var productDto = _mapper.Map<ProductDto>(product);
            _productService.AddProduct(productDto);

        }
    }
}
