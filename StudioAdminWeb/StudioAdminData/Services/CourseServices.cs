using StudioAdminData.DataAcces;
using StudioAdminData.Models.DataModels.Business;

namespace StudioAdminData.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly StudioAdminDBContext _context;
        public CourseServices(StudioAdminDBContext context)
        {
            _context = context;
        }
        public List<Course> GetCoursesWhitAnyStudent()
        {
            return _context.Courses.Where(x => x.Level == Level.Medium && x.Thirds.Any()).ToList();
        }
        public List<Course> GetCoursesByLevel()
        {
            return _context.Courses.Where(x => x.Level == Level.Expert /*&& x.Categories.Any(y => y.Name.Contains("Filosofía"))*/).ToList();
        }
        public List<Course> GetEmptyCourses()
        {
            return _context.Courses.Where(x => !x.Thirds.Any()).ToList();
        }
        public List<Course> GetAllCoursesByCategory(string CategoryName)
        {
            //var ConcretCategory = _categoryServices.GetCategoryByName(CategoryName);
            return _context.Courses.Where(x => x.Name == "").ToList();
        }

        public List<Course> GetAllCoursesWithoutChapter()
        {
            return _context.Courses.Where(x => x.Name == null).ToList();
        }

        public Course GetCoursesByName(string CourseName)
        {
            return _context.Courses.Where(x => x.Name == CourseName).First();
        }

        public string GetTemario(string CourseName)
        {
            return GetCoursesByName(CourseName).Description;
        }

        public List<Course> GetCoursesByStudent(Course Student)
        {
            return _context.Courses.Where(x => x.Thirds == Student).ToList();
        }
    }
}
