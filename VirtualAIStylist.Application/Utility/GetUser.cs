using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VirtualAIStylist.Domain.Entities;

namespace VirtualAIStylist.Application.Utility
{
	public static class GetUser
	{
		public static async Task<Account> GetCurrentUserAsync(IHttpContextAccessor _contextAccessor, UserManager<Account> _userManager)
		{
			var userClaims = _contextAccessor.HttpContext?.User;

			if (userClaims == null || !userClaims.Identity!.IsAuthenticated)
			{
				return null!;
			}

			var userEmail = userClaims.FindFirstValue(ClaimTypes.Email);

			if (string.IsNullOrEmpty(userEmail))
			{
				return null!;
			}
			return (await _userManager.FindByEmailAsync(userEmail))!;
		}
	}
}
