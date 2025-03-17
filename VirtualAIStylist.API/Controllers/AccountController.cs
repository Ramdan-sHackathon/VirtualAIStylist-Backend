using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualAIStylist.Application.Features.Authentication.Commands.CreateAccount;
using VirtualAIStylist.Application.Features.Authentication.Queries;
using VirtualAIStylist.Application.Features.Authentication.Queries.Login;
using VirtualAIStylist.Application.Utility;

namespace VirtualAIStylist.API.Controllers
{
	public class AccountController : APIBaseController
	{
		private readonly IMediator _mediator;
		public AccountController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("Register")]
		public async Task<ActionResult<Response>> Register([FromBody] CreateAccountCommand command)
		{
			return Ok(await _mediator.Send(command));
		}

		[HttpGet("Login")]
		public async Task<ActionResult<Response>> Login([FromQuery] string Email,[FromQuery] string Password)
		{
			var query=new LoginQuery
			{
				Email = Email,
				Password = Password
			};
			return Ok(await _mediator.Send(query));
		}
	}
}
