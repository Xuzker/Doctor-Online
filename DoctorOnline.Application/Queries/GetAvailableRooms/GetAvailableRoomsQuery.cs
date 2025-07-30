using MediatR;

namespace DoctorOnline.Application.Queries.GetAvailableRooms
{
    public record GetAvailableRoomsQuery(
        DateTime Date): IRequest<List<MeetingRoomDto>>;
}
