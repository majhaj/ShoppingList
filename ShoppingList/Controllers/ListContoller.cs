using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Service;


namespace Web.Controllers
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

        [HttpGet("/{id}")]
        public ActionResult<ShoppingListDto> GetById([FromRoute] int id)
        {
            var list = _listService.GetById(id);
            return Ok(list);
        }

        [HttpPost]
        public ActionResult CreateList([FromBody]CreateListDto dto)
        {
            var id = _listService.Create(dto);
            return Created($"api/list/{id}", null);
        }

        [HttpDelete("{listId}")]
        public ActionResult DeleteList([FromRoute]int listId)
        {
            _listService.Delete(listId);

            return NoContent();
        }

        [HttpPost("{listId}")]
        public ActionResult AddProductToList([FromBody]ProductDto dto, [FromRoute]int listId)
        {
            _listService.AddProductToList(dto, listId);
            return Ok();
        }

        [HttpDelete("/{listId}/{productId}")]
        public ActionResult DeleteProduct([FromRoute]int listId, [FromRoute] int productId)
        {
            _listService.DeleteProduct(listId, productId);
            return NoContent();
        }

        [HttpPut("/{listId}/{userId}")]
        public ActionResult ShareList([FromRoute]int listId, [FromRoute] int userId) 
        {
            _listService.ShareList(listId, userId);
            return Ok();
        }
    }
}
