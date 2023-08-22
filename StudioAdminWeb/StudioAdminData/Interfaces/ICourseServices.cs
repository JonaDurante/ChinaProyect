using StudioAdminData.Models.Business;

namespace StudioAdminData.Interfaces
{
    public interface ICourseServices
    {
<<<<<<< Updated upstream
        public Task<IEnumerable<Course>> GetCoursesWhitAnyStudent();
        public Task<IEnumerable<Course>> GetCoursesByLevel();
        public Task<IEnumerable<Course>> GetEmptyCourses();
        public Task<IEnumerable<Course>> GetAllCoursesByCategory(string CategoryName);
        public Task<IEnumerable<Course>> GetAllCoursesWithoutChapter();
        public Task<IEnumerable<Course>> GetAllCourses();
        public Task<Course> GetCoursesByName(string CourseName);
        public Task<Course> GetCoursesById(Guid Id);
        public Task<IEnumerable<Course>> GetCoursesByStudent(Course Third);
        public string GetTemario(string CourseName);
        public Task<bool> Update(Course course);
        public Task<bool> Insert(Course course);
        public Task<bool> Delete(Guid Id);
=======
        public Task<IEnumerable<Course>> GetAllAsync();
        public Task<Course> GetByIdAsync(Guid Id);
        public Task<IEnumerable<Course>> GetByLevelAsync(Level level);
        public Task<Course> GetByNameAsync(string CourseName);
        public Task<IEnumerable<Course>> GetByThirdAsync(Third third);
        public Task<bool> UpdateAsync(Course course);
        public Task<bool> InsertAsync(Course course);
        public Task<bool> DeleteAsync(Guid Id);
>>>>>>> Stashed changes

    }
}