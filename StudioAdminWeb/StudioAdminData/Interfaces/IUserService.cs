using StudioAdminData.Models.Business;
using StudioAdminData.Models.Loggin;

namespace StudioAdminData.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        User GetById(Guid Id);
        Task<User> GetByIdAsync(Guid Id);
        Task<bool> UpdateAsync(User user);
        Task<bool> UserExistsAsync(Guid id);
        Task<bool> InsertAsync(User user);
        Task<bool> DeleteAsync(Guid Id);
        Task<User> ValidateUserAsync(UserLoggin userLoggin);

    }
}