using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using StudioAdminData.DataAcces;
using StudioAdminData.Interfaces;
using StudioAdminData.Models.DataModels.Business;

namespace StudioAdminData.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly StudioAdminDBContext _context;
        private readonly ICommonServices<Course> _commonContext;
        public CourseServices(StudioAdminDBContext context, ICommonServices<Course> commonContext)
        {
            _context = context;
<<<<<<< Updated upstream
        }
        public async Task<IEnumerable<Course>> GetCoursesWhitAnyStudent()
        {
            return await _context.Courses.Where(x => /*x.Level == Level.Medium &&*/ x.Thirds.Any()).ToListAsync();
        }
        public async Task<IEnumerable<Course>> GetCoursesByLevel()
        {
            return await _context.Courses.Where(x => x.Level == Level.Expert /*&& x.Categories.Any(y => y.Name.Contains("Filosofía"))*/).ToListAsync();
        }
        public async Task<IEnumerable<Course>> GetEmptyCourses()
        {
            return await _context.Courses.Where(x => !x.Thirds.Any()).ToListAsync();
        }
        public async Task<IEnumerable<Course>> GetAllCoursesByCategory(string CategoryName)
        {
            //var ConcretCategory = _categoryServices.GetCategoryByName(CategoryName);
            return await _context.Courses.Where(x => x.Name == "").ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetAllCoursesWithoutChapter()
        {
            return await _commonContext.GetAllAsync();
        }
<<<<<<< Updated upstream

        public async Task<Course> GetCoursesByName(string CourseName)
        {
            return await _context.Courses.Where(x => x.Name == CourseName).FirstAsync();
        }

        public string GetTemario(string CourseName)
        {
            return GetCoursesByName(CourseName).Result.Description;
        }

        public async Task<IEnumerable<Course>> GetCoursesByStudent(Course Third)
        {
            return await _context.Courses.Where(x => x.Thirds == Third).ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _context.Courses.Where(x => x.IsDeleted != false).ToListAsync();
        }

        public async Task<Course> GetCoursesById(Guid Id)
        {
            return await _context.Courses.Where(x => x.Id == Id).FirstAsync();
        }

        public async Task<bool> Update(Course course)
        {
            var result = false;
            _context.Entry(course).State = EntityState.Modified;
            try
            {
                result = await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (GetCoursesById(course.Id) != null)
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

        public async Task<bool> Insert(Course course)
        {
            var result = false;
            try
            {
                _context.Courses.Add(course);
                result = await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            {
                //grabar en db
            }
            return result;

        }

        public async Task<bool> Delete(Guid Id)
        {
            return await _context.Courses.Where(x => x.Name == CourseName).FirstAsync();
        }
        public async Task<IEnumerable<Course>> GetByThirdAsync(Third third)
        {
            return await _context.Courses.Where(x => x.Thirds == third).ToListAsync();
        }
        public async Task<bool> InsertAsync(Course course)
        {
            return await _commonContext.InsertAsync(course);
        }
        public async Task<bool> UpdateAsync(Course course)
        {
            return await _commonContext.UpdateAsync(course);
        }
        public async Task<bool> DeleteAsync(Guid Id)
>>>>>>> Stashed changes
        {
            return await _commonContext.DeleteAsync(Id);
        }
    }
}
