using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualAIStylist.Domain.Entities;

namespace VirtualAIStylist.Persistence.Data
{
	public class VirtualAIStylistDbContext : IdentityDbContext<Account>
	{
		public VirtualAIStylistDbContext(DbContextOptions<VirtualAIStylistDbContext> options) : base(options)
		{
		}
		public DbSet<Outfit> Outfits { get; set; }
		public DbSet<Wardrobe> Wardrobes { get; set; }
		public DbSet<Piece> Pieces { get; set; }
	}
}
