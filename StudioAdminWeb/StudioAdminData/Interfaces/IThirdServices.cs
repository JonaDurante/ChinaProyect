using StudioAdminData.Models.Business;

namespace StudioAdminData.Interfaces
{
    public interface IThirdServices
    {
        public List<Third> GetStudentByAge();
        public List<Third> GetAllEnabledStudents();
        public List<Third> GetAllStudentWithOutCourses();
        public ICollection<Third> GetStudentsByCourseName(string CourseName);

    }
}