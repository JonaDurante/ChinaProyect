using Microsoft.EntityFrameworkCore;
using StudioAdminData.DataAcces;
using StudioAdminData.Interfaces;
using StudioAdminData.Models.Business;
using StudioAdminData.Models.Loggin;

namespace StudioAdminData.Services
{
    public class UserService : IUserService
    {
        private readonly StudioAdminDBContext _context;
        private readonly ICommonServices<User> _commonContext;

        public UserService(StudioAdminDBContext context, ICommonServices<User> commonContext)
        {
            _context = context;
            _commonContext = commonContext;
        }
<<<<<<< Updated upstream

        public User GetByMAil(string Email)
        {
            return await _context.Users.Where(x => x.IsDeleted == false).ToListAsync();
        }
        
        public async Task<bool> InsertAsync(User user)
        {
            return await _commonContext.InsertAsync(user);

        }
        public async Task<bool> DeleteAsync(Guid Id)
>>>>>>> Stashed changes
        {
            return await _commonContext.DeleteAsync(Id);
        }
        public async Task<bool> UserExistsAsync(Guid id)
        {
            return await _context.Users?.AnyAsync(e => e.Id == id);
        }
        public async Task<User> ValidateUserAsync(UserLoggin userLoggin)
        {
<<<<<<< Updated upstream
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
=======
            return await _context.Users.AnyAsync(e => e.Id == id);
        }
        public async Task<User> ValidateUserAsync(UserLoggin userLoggin)
        {
            return await _context.Users.FirstOrDefaultAsync(us => us.Email == userLoggin.UserName && us.Password == userLoggin.Password);
>>>>>>> Stashed changes
        }
    }
}
