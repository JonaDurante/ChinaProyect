using StudioAdminData.Models.DataModels.Business;

namespace StudioAdminData.Interfaces
{
    public interface ICourseServices
    {
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

    }
}