using InaForum.Domain.Models;
using InaForum.Logic.Commands.CreateCommands;
using InaForum.Logic.Queries.Querys;
using InaForum.Server.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InaForum.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<UserViewModel>> GetUser(Guid UserId)
        {
            var user = await _mediator.Send(new GetUserQuery(UserId));

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<UserViewModel>> CreateUser(User user)
        {
            if (user != null)
            {

                var userCreated = await _mediator.Send(
                new CreateUserCommand(
                    user.Id, user.FirstName, user.LastName, user.UserName, user.Password, user.Email));

                return CreatedAtAction("GetUser", new { UserId = userCreated.Id }, userCreated);
            }

            return BadRequest();

        }

        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<bool>> DeleteUser(Guid userId)
        {
            if (await _mediator.Send(new DeleteUserCommand(userId)))
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
