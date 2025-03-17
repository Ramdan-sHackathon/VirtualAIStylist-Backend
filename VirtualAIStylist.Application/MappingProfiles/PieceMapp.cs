using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualAIStylist.Application.Features.Pieces.Queries.GetPieces;
using VirtualAIStylist.Domain.Entities;

namespace VirtualAIStylist.Application.MappingProfiles
{
	internal class PieceMapp : IRegister
	{
		public void Register(TypeAdapterConfig config)
		{
			config.NewConfig<Piece, GetPiecesQueryDto>();
		}
	}
}
