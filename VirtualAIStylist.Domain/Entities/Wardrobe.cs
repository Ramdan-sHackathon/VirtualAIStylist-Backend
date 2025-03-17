using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualAIStylist.Domain.Entities
{
	public class Wardrobe:BaseEntity<int>
	{
		public string Name { get; set; }

		public ICollection<Piece> Pieces { get; set; } = new HashSet<Piece>();
	}
}
