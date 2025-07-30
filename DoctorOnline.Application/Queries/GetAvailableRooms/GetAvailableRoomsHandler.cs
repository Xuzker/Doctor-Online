using DoctorOnline.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorOnline.Application.Queries.GetAvailableRooms
{
    public class GetAvailableRoomsHandler : IRequestHandler<GetAvailableRoomsQuery, List<MeetingRoomDto>>
    {
        private readonly IMeetingRoomRepository _roomRepository;

        public GetAvailableRoomsHandler(IMeetingRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<List<MeetingRoomDto>> Handle(GetAvailableRoomsQuery request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetAvailableRoomsAsync(request.Date);
            return rooms.Select(r => new MeetingRoomDto
            {
                Id = r.Id,
                Name = r.Name.Value,
                Capacity = r.Capacity
            }).ToList();
        }
    }
}
