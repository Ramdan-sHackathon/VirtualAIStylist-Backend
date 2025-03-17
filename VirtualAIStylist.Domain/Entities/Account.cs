using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualAIStylist.Domain.Entities
{
	public class Account : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }
		public bool Gender { get; set; }

		public ICollection<Outfit> Outfits { get; set; } = new HashSet<Outfit>();
		public ICollection<Piece> Pieces { get; set; } = new HashSet<Piece>();
	}
}
