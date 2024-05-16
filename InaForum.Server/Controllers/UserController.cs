using InaForum.Domain.Models;
using InaForum.Logic.Querys;
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
        public async Task<ActionResult<UserViewModel>> GetUser(Guid Id)
        {
            var user = await _mediator.Send(new GetUserQuery(Id));

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }
    }
}
