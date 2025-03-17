using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualAIStylist.Application.Utility;
using VirtualAIStylist.Domain.Entities;
using VirtualAIStylist.Domain.Repositories;

namespace VirtualAIStylist.Application.Features.Pieces.Queries.GetPieces
{
	public class GetPiecesQuery : IRequest<Response>
	{
		public int WardrobeId { get; set; }
		public GetPiecesQuery(int Id)
		{
			WardrobeId = Id;
		}
	}
	public class GetPiecesQueryHandler : IRequestHandler<GetPiecesQuery, Response>
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetPiecesQueryHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<Response> Handle(GetPiecesQuery request, CancellationToken cancellationToken)
		{
			var pieces = await _unitOfWork.Repository<int, Piece>().GetWithPrdicate(p => p.WardrobeId == request.WardrobeId);
			return await Response.Success(pieces.Adapt<IReadOnlyList<GetPiecesQueryDto>>(), "Pieces Comes Successfully!");
		}
	}

}
