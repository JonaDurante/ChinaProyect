using StudioAdminData.Models.DataModels.Business;

namespace StudioAdminData.Services
{
    public interface IUserService
    {
        public User GetByMAil(string Email);
        public List<User> GetUserWhitOutCourses();
        public List<User> GetAll();
    }
}