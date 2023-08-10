using Microsoft.EntityFrameworkCore;
using StudioAdminData.Models.DataModels;

namespace StudioAdminData.Services
{
    public interface IUserService
    {
        public User GetByMAil(string Email);
        public List<User> GetUserWhitOutCourses();
        public List<User> GetAll();
    }
}