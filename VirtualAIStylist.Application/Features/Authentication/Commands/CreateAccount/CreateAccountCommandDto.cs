using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualAIStylist.Application.Features.Authentication.Commands.CreateAccount
{
	public class CreateAccountCommandDto
	{
		public string Id { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public string Token { get; set; }
	}
}
