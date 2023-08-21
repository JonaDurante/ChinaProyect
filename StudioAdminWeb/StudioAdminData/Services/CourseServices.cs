using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using StudioAdminData.DataAcces;
using StudioAdminData.Interfaces;
using StudioAdminData.Models.Business;

namespace StudioAdminData.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly StudioAdminDBContext _context;
        public CourseServices(StudioAdminDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Course>> GetCoursesWhitAnyStudentAsync()
        {
            return await _context.Courses.Where(x => /*x.Level == Level.Medium &&*/ x.Thirds.Any()).ToListAsync();
        }
        public async Task<IEnumerable<Course>> GetCoursesByLevelAsync()
        {
            return await _context.Courses.Where(x => x.Level == Level.Expert /*&& x.Categories.Any(y => y.Name.Contains("Filosofía"))*/).ToListAsync();
        }
        public async Task<IEnumerable<Course>> GetEmptyCoursesAsync()
        {
            return await _context.Courses.Where(x => !x.Thirds.Any()).ToListAsync();
        }
        public async Task<IEnumerable<Course>> GetAllCoursesByCategoryAsync(string CategoryName)
        {
            //var ConcretCategory = _categoryServices.GetCategoryByName(CategoryName);
            return await _context.Courses.Where(x => x.Name == "").ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetAllCoursesWithoutChapterAsync()
        {
            return await _context.Courses.Where(x => x.Name == null).ToListAsync();
        }

        public async Task<Course> GetCoursesByNameAsync(string CourseName)
        {
            return await _context.Courses.Where(x => x.Name == CourseName).FirstAsync();
        }

        public string GetTemarioAsync(string CourseName)
        {
            return GetCoursesByNameAsync(CourseName).Result.Description;
        }

        public async Task<IEnumerable<Course>> GetCoursesByStudentAsync(Course Third)
        {
            return await _context.Courses.Where(x => x.Thirds == Third).ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.Where(x => x.IsDeleted != false).ToListAsync();
        }

        public async Task<Course> GetCoursesByIdAsync(Guid Id)
        {
            return await _context.Courses.Where(x => x.Id == Id).FirstAsync();
        }

        public async Task<bool> UpdateAsync(Course course)
        {
            var result = false;
            _context.Entry(course).State = EntityState.Modified;
            try
            {
                result = await _context.SaveChangesAsync() > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (GetCoursesByIdAsync(course.Id) != null)
                {
                    return result;
                }
                else
                {
                    //guardar error
                }
            }
            return result;
        }

        public async Task<bool> InsertAsync(Course course)
        {
            var result = false;
            try
            {
                _context.Courses.Add(course);
                result = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                //grabar en db
            }
            return result;

        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var course = await _context.Courses.FindAsync(Id);
            if (course == null)
            {
                return false;
            }
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
