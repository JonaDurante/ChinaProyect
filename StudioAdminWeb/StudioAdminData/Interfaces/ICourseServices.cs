using StudioAdminData.Models.Business;

namespace StudioAdminData.Interfaces
{
    public interface ICourseServices
    {
        public Task<IEnumerable<Course>> GetAllAsync();
        public Task<Course> GetByIdAsync(Guid Id);
        public Task<IEnumerable<Course>> GetByLevelAsync(Level level);
        public Task<Course> GetByNameAsync(string CourseName);
        public Task<IEnumerable<Course>> GetByIdDate(Guid IdDate);
        public Task<bool> UpdateAsync(Course course);
        public Task<bool> InsertAsync(Course course);
        public Task<bool> DeleteAsync(Guid Id);
 

    }
}