using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualAIStylist.Domain.Entities;

namespace VirtualAIStylist.Domain.Interfaces
{
	public interface IAuthService
	{
		Task<string> CreateTokenAsync(Account user, UserManager<Account> _userManager);

	}
}
