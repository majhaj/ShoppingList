﻿using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Service;


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
        public ActionResult<ProductsListDto> GetById([FromRoute] int id)
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

        [HttpDelete("{id}")]
        public ActionResult DeleteList([FromRoute]int id)
        {
            _listService.Delete(id);

            return NoContent();
        }

        [HttpPost("{id}")]
        public ActionResult AddProductToList([FromBody]string product, [FromRoute]int id)
        {
            _listService.AddProductToList(product, id);
            return Ok(product);
        }

        [HttpDelete("/deleteproduct/{id}")]
        public ActionResult DeleteProduct([FromBody]string product, [FromRoute]int id)
        {
            _listService.DeleteProduct(product, id);
            return NoContent();
        }
    }
}
