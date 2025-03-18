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
using VirtualAIStylist.Domain.Interfaces;
using VirtualAIStylist.Domain.Repositories;

namespace VirtualAIStylist.Application.Features.Pieces.Commands.DeletePieces
{
	public class DeletePiecesCommand : IRequest<Response>
	{
		public List<int> Pieces { get; set; }
	}
	public class DeletePiecesCommandHandler : IRequestHandler<DeletePiecesCommand, Response>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMediaService _media;
		private readonly IHttpContextAccessor _contextAccessor;
		private readonly UserManager<Account> _userManager;
		public DeletePiecesCommandHandler(IUnitOfWork unitOfWork, IMediaService media, UserManager<Account> userManager, IHttpContextAccessor contextAccessor)
		{
			_unitOfWork = unitOfWork;
			_media = media;
			_userManager = userManager;
			_contextAccessor = contextAccessor;
		}

		public async Task<Response> Handle(DeletePiecesCommand request, CancellationToken cancellationToken)
		{
			var user = await GetUser.GetCurrentUserAsync(_contextAccessor, _userManager);
			if (user == null)
			{
				return await Response.Fail("UnAuthorized", HttpStatusCode.Unauthorized);
			}

			foreach (var pieceId in request.Pieces)
			{
				var piece = (await _unitOfWork.Repository<int, Piece>().GetWithPrdicate(p => p.Id == pieceId && p.AccountId == user.Id)).FirstOrDefault();
				if (piece is not null)
				{
					if (piece.ImageUrl is not null)
					{
						await _media.DeleteAsync(piece.ImageUrl);
					}
					_unitOfWork.Repository<int, Piece>().Remove(piece);
					await _unitOfWork.SaveChangesAsync();
				}
			}
			return await Response.Success(null!, "Pieces deleted successfully!");
		}
	}
}
