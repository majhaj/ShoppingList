using Application.Models;
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
        public ActionResult<CreateUserDto> GetUserById([FromRoute]int id)
        {
           var user = _accountService.GetUserById(id);
            return Ok(user);
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody]CreateUserDto dto)
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
        public ActionResult UpdateUser([FromRoute] int id, [FromBody]CreateUserDto dto)
        {
            _accountService.UpdateUser(id, dto);
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody]LoginDto dto)
        {
            string token = _accountService.GenerateJwtToken(dto);
            return Ok(token);
        }
    }
}
