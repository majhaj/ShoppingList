using Application.List;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Route("api/list")]
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
            var list = _listService.GetListById(id);
            return Ok(list);
        }

        [HttpPost]
        public ActionResult CreateList([FromBody] CreateListDto dto)
        {
            var id = _listService.CreateList(dto);
            return Created($"api/list/{id}", null);
        }

        [HttpDelete("{listId}")]
        public ActionResult DeleteList([FromRoute] int listId)
        {
            _listService.DeleteList(listId);

            return NoContent();
        }

        [HttpPost("{listId}")]
        public ActionResult AddItemToList([FromBody] ItemDto dto, [FromRoute] int listId)
        {
            _listService.AddItemToList(dto, listId);
            return Ok();
        }

        [HttpDelete("/{listId}/{productId}")]
        public ActionResult DeleteItem([FromRoute] int listId, [FromRoute] int productId)
        {
            _listService.DeleteItem(listId, productId);
            return NoContent();
        }

        [HttpPut("/{listId}/{userId}")]
        public ActionResult ShareList([FromRoute] int listId, [FromRoute] int userId)
        {
            _listService.ShareList(listId, userId);
            return Ok();
        }

    }
}
