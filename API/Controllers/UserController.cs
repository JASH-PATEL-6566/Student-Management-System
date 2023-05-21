using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Users;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult> AddUser(User user)
        {
            return Ok(await Mediator.Send(new AddUser.Command { User = user }));
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return Ok(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{req}")]
        public async Task<ActionResult<User>> CheckUser(String req)
        {
            return Ok(await Mediator.Send(new Check.Query { LoginInfo = req }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Query { Id = id }));
        }
    }
}