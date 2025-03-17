using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualAIStylist.Domain.Entities;

namespace VirtualAIStylist.Application.Features.Pieces.Queries.GetPieces
{
	internal class GetPiecesQueryDto
	{
		public int Id { get; set; }
		public string ImageUrl { get; set; }

	}
}
