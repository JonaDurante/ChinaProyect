using StudioAdminData.DataAcces;
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

        public List<User> GetAll()
        {
            return _context.Users.Where(x => x.IsDeleted == false).ToList();            
        }
    }
}
