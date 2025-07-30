using DoctorOnline.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorOnline.Infrastructure.Config
{
    public class AppDbContext : DbContext
    {
        public DbSet<MeetingRoom> MeetingRooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
