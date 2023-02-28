using Application.Models;
using Application.Products;
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

        [HttpPost]
        public ActionResult CreateProduct([FromBody] ProductDto dto)
        {
            var id = _productService.AddProduct(dto);
            return Created($"api/product/{id}", null);
        }

        [HttpPost("/{productId}")]
        public ActionResult UpdateProduct([FromRoute] int productId, ProductDto dto)
        {
            _productService.UpdateProduct(productId, dto);
            return Ok();
        }

        [HttpDelete("/{productId}")]
        public ActionResult DeleteProduct([FromRoute] int productId)
        {
            _productService.DeleteProduct(productId);
            return NoContent();
        }  
    }
}
