using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PR1.ActionClass.Account;
using PR1.ActionClass.HelperClass.DTO;
using PR1.Interface;


namespace PR1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _IUser;
        public UserController(IUser iUser) => _IUser = iUser;

        [HttpPost("user/addAccount")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
         public async Task<ActionResult<List<string>>> Post(AccountDTO account) => await Task.FromResult(_IUser.AddAccount(account));

        [HttpGet("users")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> Get() => await Task.FromResult(_IUser.GetUsers());

        [HttpGet("users/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<AccountDTO>>> Get(string login) => await Task.FromResult(_IUser.GetUser(login));

        [HttpDelete("user/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<string>>> Delete(int id) => await Task.FromResult(_IUser.DeletUser(id));

        [HttpPatch("user/UpdateUser")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<string>>> Patch(int id, AccountDTO user) => await Task.FromResult(_IUser.UpdateUser(id, user));


    }
}
