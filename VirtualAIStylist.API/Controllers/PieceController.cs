using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualAIStylist.Application.Features.Pieces.Commands.AddPieces;
using VirtualAIStylist.Application.Features.Pieces.Commands.DeletePieces;
using VirtualAIStylist.Application.Features.Pieces.Queries.GetPieces;
using VirtualAIStylist.Application.Utility;

namespace VirtualAIStylist.API.Controllers
{
	[Authorize(AuthenticationSchemes ="Bearer")]
	public class PieceController : APIBaseController
	{
		private readonly IMediator _mediator;

		public PieceController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("add-pieces")]
		public async Task<ActionResult<Response>> AddPiece([FromForm]AddPiecesCommand command)
		{
			return Ok(await _mediator.Send(command));
		}

		[HttpGet("get-pieces/{WardrobeId}")]
		public async Task<ActionResult<Response>> GetPieces([FromRoute]int WardrobeId)
		{
			var query = new GetPiecesQuery(WardrobeId);
			return Ok(await _mediator.Send(query));
		}

		[HttpDelete("delete-pieces")]
		public async Task<ActionResult<Response>> DeletePieces([FromBody] DeletePiecesCommand command)
		{
			return Ok(await _mediator.Send(command));
		}

	}
}
