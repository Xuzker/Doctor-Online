using CSharpFunctionalExtensions;
using DoctorOnline.Domain.Repositories;
using DoctorOnline.Domain.Services;
using DoctorOnline.Domain.ValueObjects;
using MediatR;

namespace DoctorOnline.Application.Commands.BookMeetingRoom
{
    public class BookMeetingRoomHandler : IRequestHandler<BookMeetingRoomCommand, Result>
    {
        private readonly IMeetingRoomRepository _roomRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationService _notificationService;

        public BookMeetingRoomHandler(
            IMeetingRoomRepository roomRepository, 
            IUserRepository userRepository, 
            IUnitOfWork unitOfWork, 
            INotificationService notificationService)
        {
            _roomRepository = roomRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _notificationService = notificationService;
        }

        public async Task<Result> Handle(BookMeetingRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetByIdAsync(request.RoomId);
            if (room is null)
                return Result.Failure("Meeting room not found");

            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user is null)
                return Result.Failure("User not found");

            var timeRangeResult = TimeRange.Create(request.Start, request.End);
            if (timeRangeResult.IsFailure)
                return Result.Failure(timeRangeResult.Error);

            var bookingResult = room.Book(timeRangeResult.Value, user.Id);
            if (bookingResult.IsFailure)
                return Result.Failure(bookingResult.Error);

            await _unitOfWork.SaveChangesAsync();

            await _notificationService.SendBookingConfirmationEmail(user.Email.Value, room.Name.Value, request.Start, request.End);

            return Result.Success();
        }
    }
}
