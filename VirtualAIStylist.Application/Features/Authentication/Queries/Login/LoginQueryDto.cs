﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualAIStylist.Application.Features.Authentication.Queries.Login
{
	internal class LoginQueryDto
	{
		public string Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public bool Gender { get; set; }
		public int Age { get; set; }
		public string Token { get; set; } = string.Empty;
	}
}
