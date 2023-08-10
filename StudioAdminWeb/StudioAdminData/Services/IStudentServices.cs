using StudioAdminData.Models.DataModels;

namespace StudioAdminData.Services
{
    public interface IStudentServices
    {
        public List<Student> GetStudentByAge();
        public List<Student> GetAllEnabledStudents();
        public List<Student> GetAllStudentWithOutCourses();
        public ICollection<Student> GetStudentsByCourseName(string CourseName);

    }
}