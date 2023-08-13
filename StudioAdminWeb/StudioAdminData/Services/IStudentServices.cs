using StudioAdminData.Models.DataModels.Business;

namespace StudioAdminData.Services
{
    public interface IStudentServices
    {
        public List<Third> GetStudentByAge();
        public List<Third> GetAllEnabledStudents();
        public List<Third> GetAllStudentWithOutCourses();
        public ICollection<Third> GetStudentsByCourseName(string CourseName);

    }
}