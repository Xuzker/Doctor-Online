using DoctorOnline.Application.Commands.BookMeetingRoom;
using DoctorOnline.Application.Queries.GetAvailableRooms;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoctorOnline.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingRoomsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MeetingRoomsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Получить доступные комнаты на определенную дату.
        /// </summary>
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableRooms([FromQuery] DateTime date)
        {
            var query = new GetAvailableRoomsQuery(date);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Забронировать комнату.
        /// </summary>
        [HttpPost("book")]
        public async Task<IActionResult> BookMeetingRoom([FromBody] BookMeetingRoomCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
                return Ok();

            return BadRequest(result.Error);
        }
    }
}
