using StudioAdminData.Models.Business;

namespace StudioAdminData.Interfaces
{
    public interface ICourseServices
    {
        public Task<IEnumerable<Course>> GetCoursesWhitAnyStudentAsync();
        public Task<IEnumerable<Course>> GetCoursesByLevelAsync();
        public Task<IEnumerable<Course>> GetEmptyCoursesAsync();
        public Task<IEnumerable<Course>> GetAllCoursesByCategoryAsync(string CategoryName);
        public Task<IEnumerable<Course>> GetAllCoursesWithoutChapterAsync();
        public Task<IEnumerable<Course>> GetAllCoursesAsync();
        public Task<Course> GetCoursesByNameAsync(string CourseName);
        public Task<Course> GetCoursesByIdAsync(Guid Id);
        public Task<IEnumerable<Course>> GetCoursesByStudentAsync(Course Third);
        public string GetTemarioAsync(string CourseName);
        public Task<bool> UpdateAsync(Course course);
        public Task<bool> InsertAsync(Course course);
        public Task<bool> DeleteAsync(Guid Id);

    }
}