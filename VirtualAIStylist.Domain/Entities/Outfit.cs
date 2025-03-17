using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualAIStylist.Domain.Entities
{
	public class Outfit:BaseEntity<int>
	{
		public string ImageUrl { get; set; }
		public string Description { get; set; }

		public string AccountId { get; set; }
		public Account Account { get; set; }
	}
}
