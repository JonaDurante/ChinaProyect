using StudioAdminData.Models.DataModels.Business;

namespace StudioAdminData.Interfaces
{
    public interface IUserService
    {
        public User GetByMAil(string Email);
        public List<User> GetUserWhitOutCourses();
        public Task<List<User>> GetAll();
        public Task<User> GetById(Guid Id);
        public Task<bool> Update(User user);
        public bool UserExists(Guid id);
        public Task<bool> Insert(User user);
        public Task<bool> Delete(User user);
    }
}