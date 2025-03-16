using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualAIStylist.Domain.Entities
{
	public class Account:IdentityUser
	{
		public ICollection<Outfit> Outfits { get; set; }=new HashSet<Outfit>();
		public ICollection<Piece> Pieces { get; set; } = new HashSet<Piece>();
	}
}
