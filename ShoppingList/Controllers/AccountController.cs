using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Application.Account;

namespace API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService userService)
        {
            _accountService = userService;
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUserById([FromRoute]int id)
        {
           var user = _accountService.GetUserById(id);
            return Ok(user);
        }

        [HttpPost]
        public ActionResult CreateUser([FromBody]UserDto dto)
        {
            var id = _accountService.CreateUser(dto);
            return Created($"api/user/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser([FromRoute]int id)
        {
            _accountService.DeleteUser(id);
            return NoContent();
        }

        [HttpPost("{id}")]
        public ActionResult UpdateUser([FromRoute] int id, [FromBody]UserDto dto)
        {
            _accountService.UpdateUser(id, dto);
            return Ok();
        }
    }
}
