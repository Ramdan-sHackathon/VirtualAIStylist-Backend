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
using VirtualAIStylist.Domain.Interfaces;

namespace VirtualAIStylist.Application.Features.Authentication.Queries.Login
{
	public class LoginQuery : IRequest<Response>
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
	public class LoginQueryHandler : IRequestHandler<LoginQuery, Response>
	{
		private readonly SignInManager<Account> _singInManager;
		private readonly UserManager<Account> _userManager;
		private readonly IAuthService _authService;
		public LoginQueryHandler(SignInManager<Account> singInManager, UserManager<Account> userManager, IAuthService authService)
		{
			_singInManager = singInManager;
			_userManager = userManager;
			_authService = authService;
		}

		public async Task<Response> Handle(LoginQuery request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);
			if (user == null)
			{
				return await Response.Fail("Email not found!");
			}

			var result = await _singInManager.PasswordSignInAsync(user, request.Password, true, true);
			if (!result.Succeeded)
			{
				return await Response.Fail("Invalid `Password`", HttpStatusCode.BadRequest);
			}

			return await Response.Success(new LoginQueryDto
			{
				Id = user.Id,
				Email = user.Email,
				UserName = user.UserName,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Age = user.Age,
				Gender = user.Gender,
				Token=await _authService.CreateTokenAsync(user,_userManager)
			}, "Logged in successfully!");
		}
	}
}
