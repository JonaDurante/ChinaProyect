using StudioAdminData.Models.DataModels.Business;

namespace StudioAdminData.Services
{
    public interface ICourseServices
    {
        public List<Course> GetCoursesWhitAnyStudent();
        public List<Course> GetCoursesByLevel();
        public List<Course> GetEmptyCourses();
        public List<Course> GetAllCoursesByCategory(string CategoryName);
        public List<Course> GetAllCoursesWithoutChapter();
        public Course GetCoursesByName(string CourseName);
        public List<Course> GetCoursesByStudent(Course Student);
        public string GetTemario(string CourseName);

    }
}