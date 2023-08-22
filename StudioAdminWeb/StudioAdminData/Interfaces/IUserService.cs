using StudioAdminData.Models.Business;
using StudioAdminData.Models.Loggin;

namespace StudioAdminData.Interfaces
{
    public interface IUserService
    {
<<<<<<< Updated upstream
        public User GetByMAil(string Email);
        public List<User> GetUserWhitOutCourses();
        public Task<List<User>> GetAll();
        public Task<User> GetById(Guid Id);
        public Task<bool> Update(User user);
        public bool UserExists(Guid id);
        public Task<bool> Insert(User user);
        public Task<bool> Delete(User user);
=======
        Task<IEnumerable<User>> GetAllAsync();
        User GetById(Guid Id);
        Task<User> GetByIdAsync(Guid Id);
        Task<bool> UpdateAsync(User user);
        Task<bool> UserExistsAsync(Guid id);
        Task<bool> InsertAsync(User user);
        Task<bool> DeleteAsync(Guid Id);
        Task<User> ValidateUserAsync(UserLoggin userLoggin);

>>>>>>> Stashed changes
    }
}