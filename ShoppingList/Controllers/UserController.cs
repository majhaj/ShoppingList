using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/user/")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUserById([FromRoute]int id)
        {
           var user = _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpPost]
        public ActionResult CreateUser([FromBody]UserDto dto)
        {
            var id = _userService.CreateUser(dto);
            return Created($"api/user/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser([FromRoute]int id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }

        [HttpPost("{id}")]
        public ActionResult UpdateUser([FromRoute] int id, [FromBody]UserDto dto)
        {
            _userService.UpdateUser(id, dto);
            return Ok();
        }
    }
}
