using Microsoft.AspNetCore.Mvc;
using ShoppingList.Models;
using ShoppingList.Services;

namespace ShoppingList.Controllers
{
    [ApiController]
    [Route("api/list/")]
    public class ListContoller : Controller
    {
        private readonly IListService _listService;

        public ListContoller(IListService listService)
        {
            _listService = listService;
        }

        [HttpGet]
        ActionResult<ProductsListDto> GetById([FromRoute] int id)
        {
            var list = _listService.GetById(id);
            return Ok(list);
        }

        [HttpPost]
        ActionResult CreateList([FromBody]CreateListDto dto)
        {
            var id = _listService.Create(dto);
            return Created($"api/list/{id}", null);
        }

        [HttpDelete("{id}")]
        ActionResult DeleteList([FromRoute]int id)
        {
            _listService.Delete(id);

            return NoContent();
        }

        [HttpPost("{id}")]
        ActionResult AddProductToList([FromBody]string product, [FromRoute]int id)
        {
            _listService.AddProductToList(product, id);
            return Ok(product);
        }
    }
}
