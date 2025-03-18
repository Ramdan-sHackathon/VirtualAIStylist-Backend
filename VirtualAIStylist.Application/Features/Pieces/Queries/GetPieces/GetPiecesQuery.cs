using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
		private readonly IHttpContextAccessor _contextAccessor;
		private readonly UserManager<Account> _userManager;
		public GetPiecesQueryHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor, UserManager<Account> userManager)
		{
			_unitOfWork = unitOfWork;
			_contextAccessor = contextAccessor;
			_userManager = userManager;
		}
		public async Task<Response> Handle(GetPiecesQuery request, CancellationToken cancellationToken)
		{
			var user = await GetUser.GetCurrentUserAsync(_contextAccessor, _userManager);
			if (user == null)
			{
				return await Response.Fail("UnAuthorized", HttpStatusCode.Unauthorized);
			}

			var pieces = await _unitOfWork.Repository<int, Piece>().GetWithPrdicate(p => p.WardrobeId == request.WardrobeId && p.AccountId == user.Id);
			return await Response.Success(pieces.Adapt<IReadOnlyList<GetPiecesQueryDto>>(), "Pieces Comes Successfully!");
		}
	}

}
