using StudioAdminData.Models.Business;

namespace StudioAdminData.Interfaces
{
    public interface IThirdServices
    {
        Task<IEnumerable<Third>> GetAllAsync();
        Task<Third> GetByIdAsync(Guid id);
        public IEnumerable<Third> GetByAge(int age);
        public IEnumerable<Third> GetAllEnabledStudents();
        Task<bool> InsertAsync(Third Entity);
        Task<bool> UpdateAsync(Third Entity);
        Task<bool> DeleteAsync(Guid Id);
    }
}