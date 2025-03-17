using MediatR;
using Microsoft.AspNetCore.Http;
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
		public int WordrobeId { get; set; }
		public List<IFormFile> Pieces { get; set; }
	}
	internal class AddPiecesCommandHandler : IRequestHandler<AddPiecesCommand, Response>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMediaService _media;
		public AddPiecesCommandHandler(IUnitOfWork unitOfWork, IMediaService media)
		{
			_unitOfWork = unitOfWork;
			_media = media;
		}

		public async Task<Response> Handle(AddPiecesCommand request, CancellationToken cancellationToken)
		{
			var wordrobe = await _unitOfWork.Repository<int, Wardrobe>().GetByIdAsync(request.WordrobeId);
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
						ImageUrl = await _media.UploadImageAsync(image)!
					});
				}
			}
			await _unitOfWork.Repository<int, Piece>().AddRangeAsync(pieces);
			int added = await _unitOfWork.SaveChangesAsync();
			return await Response.Success(null, $"`{added}`Pieces added successfully!");
		}

	}
}
