using DoctorOnline.Application.Commands.BookMeetingRoom;
using DoctorOnline.Infrastructure.Config;
using DoctorOnline.Domain.Repositories;
using DoctorOnline.Infrastructure.Persistence;
using DoctorOnline.Domain.Services;
using DoctorOnline.Infrastructure.Notifications;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Добавляем контроллеры
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MediatR — регистрация обработчиков из Application слоя
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(BookMeetingRoomCommand).Assembly);
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Регистрация зависимостей
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMeetingRoomRepository, MeetingRoomRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();

builder.Services.AddSignalR();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Маршрутизация контроллеров
app.MapControllers();

app.Run();