using CSharpFunctionalExtensions;
using MediatR;

namespace DoctorOnline.Application.Commands.BookMeetingRoom
{
    public record BookMeetingRoomCommand(
        Guid RoomId,
        Guid UserId,
        DateTime Start,
        DateTime End
        ) : IRequest<Result>;
}
