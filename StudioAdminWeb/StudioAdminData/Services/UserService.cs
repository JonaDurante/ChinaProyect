using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StudioAdminData.DataAcces;
using StudioAdminData.Interfaces;
using StudioAdminData.Models.DataModels.Business;

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

        public User GetByMAil(string Email)
        {
            return _context.Users.Where(x => x.Email == Email).First();
        }

        public List<User> GetUserWhitOutCourses()
        {
            var Users = _context.Users.Where(x => !x.IsDeleted == false).ToList();
            var Curses = _courseServices.GetCoursesWhitAnyStudent();
            return Users;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.Where(x => x.IsDeleted == false).ToListAsync();
        }
        public async Task<User> GetById(Guid Id)
        {
            return await _context.Users.Where(x => x.Id == Id && x.IsDeleted == false).FirstAsync();
        }

        public async Task<bool> Update(User user)
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

                //if (!UserExists(id))
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

        public async Task<bool> Insert(User user) {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync() > 0 ? true : false;

        }
        public async Task<bool> Delete(User user)
        {
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public bool UserExists(Guid id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
