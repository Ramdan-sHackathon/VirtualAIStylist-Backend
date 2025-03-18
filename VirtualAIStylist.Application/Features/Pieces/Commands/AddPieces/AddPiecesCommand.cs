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

namespace VirtualAIStylist.Application.Features.Pieces.Commands.AddPieces
{
	public class AddPiecesCommand : IRequest<Response>
	{
		public int WardrobeId { get; set; }
		public List<IFormFile> Pieces { get; set; }
	}
	internal class AddPiecesCommandHandler : IRequestHandler<AddPiecesCommand, Response>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMediaService _media;
		private readonly IHttpContextAccessor _contextAccessor;
		private readonly UserManager<Account> _userManager;
		public AddPiecesCommandHandler(IUnitOfWork unitOfWork, IMediaService media, IHttpContextAccessor contextAccessor, UserManager<Account> userManager)
		{
			_unitOfWork = unitOfWork;
			_media = media;
			_contextAccessor = contextAccessor;
			_userManager = userManager;
		}

		public async Task<Response> Handle(AddPiecesCommand request, CancellationToken cancellationToken)
		{
			var user=await GetUser.GetCurrentUserAsync(_contextAccessor, _userManager);
			if(user==null)
			{
				return await Response.Fail("UnAuthorized", HttpStatusCode.Unauthorized);
			}

			var wordrobe = await _unitOfWork.Repository<int, Wardrobe>().GetByIdAsync(request.WardrobeId);
			if (wordrobe == null)
			{
				return await Response.Fail("Wordrobe not found!", HttpStatusCode.NotFound);
			}
			var pieces = new List<Piece>();

			foreach (var image in request.Pieces)
			{
				if (image != null)
				{

					pieces.Add(new Piece
					{
						WardrobeId = wordrobe.Id,
						ImageUrl = await _media.UploadImageAsync(image)!,
						AccountId=user.Id
					});
				}
			}
			await _unitOfWork.Repository<int, Piece>().AddRangeAsync(pieces);
			int added = await _unitOfWork.SaveChangesAsync();
			return await Response.Success(null, $"`{added}`Pieces added successfully!");
		}

	}
}
