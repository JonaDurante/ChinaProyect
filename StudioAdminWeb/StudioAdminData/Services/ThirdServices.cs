using StudioAdminData.DataAcces;
using StudioAdminData.Interfaces;
using StudioAdminData.Models.DataModels.Business;

namespace StudioAdminData.Services
{
    public class ThirdServices : IThirdServices
    {
        private readonly StudioAdminDBContext _context;
        private readonly ICourseServices _courseServices;

        public ThirdServices(StudioAdminDBContext context, ICourseServices courseServices)
        {
            _context = context;
            _courseServices = courseServices;
        }

        public List<Third> GetStudentByAge()
        {
            var actualDate = DateTime.Today;
            return _context.Thirds.Where(x => (actualDate - x.DateOfBirthday).TotalDays / 365.25 > 18).ToList();
        }
        public List<Third> GetAllEnabledStudents()
        {
            return _context.Thirds.Where(x => x.IsDeleted == false).ToList();
        }
        public List<Third> GetAllStudentWithOutCourses()
        {
            var CoursesWithStudents = _courseServices.GetCoursesWhitAnyStudent();
            var Thirds = GetAllEnabledStudents();
            var StudentsInCourses = CoursesWithStudents.SelectMany(c => c.Thirds).ToList();
            var StudentsWithoutCourses = Thirds.Where(s => !StudentsInCourses.Contains(s)).ToList();
            return StudentsWithoutCourses;
        }

        public ICollection<Third> GetStudentsByCourseName(string CourseName) {
            return _courseServices.GetCoursesByName(CourseName).Thirds;
        }

   
    }
}
