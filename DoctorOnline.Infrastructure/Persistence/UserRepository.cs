using DoctorOnline.Domain.Entities;
using DoctorOnline.Domain.Repositories;
using DoctorOnline.Infrastructure.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorOnline.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _appDbContext.Users.FindAsync(id);
        }
    }
}
