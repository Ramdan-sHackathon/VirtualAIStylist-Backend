using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VirtualAIStylist.Application.Utility;
using VirtualAIStylist.Domain.Entities;

namespace VirtualAIStylist.Application.Features.Authentication.Commands.CreateAccount
{
	public class CreateAccountCommand : IRequest<Response>
	{
		public string FristName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string password { get; set; }
		public string ConfirmPassword { get; set; }
		public bool Gender { get; set; }
		public int Age { get; set; }

	}
	public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Response>
	{
		private readonly UserManager<Account> _userManager;

		public CreateAccountCommandHandler(UserManager<Account> userManager)
		{
			_userManager = userManager;
		}

		public async Task<Response> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);

			if (user != null)
			{
				return await Response.Fail("Email already Exist!", HttpStatusCode.BadRequest);
			}

			var account = new Account
			{
				FirstName = request.FristName,
				LastName = request.LastName,
				Email = request.Email,
				Gender = request.Gender,
				Age = request.Age,
				UserName = request.Email.Split()[0]
			};

			await _userManager.CreateAsync(account, request.password);

			//TODO: Generate Token

			return await Response.Success(new CreateAccountCommandDto
			{
				Id = account.Id,
				UserName = account.UserName,
				Email = account.Email,
				Token = "Token"
			}, "Registration Successfully.");

		}
	}
}
