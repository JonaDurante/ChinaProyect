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
        private readonly ICourseServices _courseServices;

        public UserService(StudioAdminDBContext context, ICourseServices courseServices)
        {
            _context = context;
            _courseServices = courseServices;
        }
        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.Where(x => x.IsDeleted == false).ToListAsync();
        }
        public async Task<User> GetByIdAsync(Guid Id)
        {
            return await _context.Users.Where(x => x.Id == Id && x.IsDeleted == false).FirstAsync();
        }        
        public User GetById(Guid Id)
        {
            return _context.Users.Where(x => x.Id == Id && x.IsDeleted == false).First();
        }
        public async Task<bool> UpdateAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            var result = false;
            try
            {
                result = await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (DbUpdateConcurrencyException)
            {
                //guardar en db

                //if (!UserExistsAsync(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }
            return result;
        }
        public async Task<bool> InsertAsync(User user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync() > 0 ? true : false;

        }
        public async Task<bool> DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }
        public async Task<bool> UserExistsAsync(Guid id)
        {
            return await _context.Users?.AnyAsync(e => e.Id == id);
        }
        public async Task<User> ValidateUserAsync(UserLoggin userLoggin)
        {
            return await _context.Users?.FirstOrDefaultAsync(us => us.Name == userLoggin.UserName && us.Password == userLoggin.Password);
        }
    }
}
