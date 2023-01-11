using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace ShoppingList.Controllers
{
    [ApiController]
    [Route("api/product/")]
    public class ProductContoller : Controller
    {
        private readonly IProductService _service;

        public ProductContoller(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult AddProduct([FromBody]ProductDto dto)
        {
            var id = _service.AddProduct(dto);
            return Created($"api/product/{id}", null);
        }

        [HttpDelete]
        public ActionResult DeleteProduct([FromRoute] int id) 
        {
            _service.DeleteProduct(id);
            return NoContent();
        }

        [HttpPost("{id}")]
        public ActionResult UpdateProduct([FromBody] ProductDto dto, [FromRoute] int id)
        {
            _service.UpdateProduct(dto, id);
            return Ok();
        }
    }
}
