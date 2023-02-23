using Application.Products;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("/{productId}")]
        public ActionResult UpdateProduct([FromRoute] int productId, ProductDto dto)
        {
            _productService.UpdateProduct(productId, dto);
            return Ok();
        }
    }
}
