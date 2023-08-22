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
        private readonly ICommonServices<Course> _commonContext;
        public CourseServices(StudioAdminDBContext context, ICommonServices<Course> commonContext)
        {
            _context = context;
            _commonContext = commonContext;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _commonContext.GetAllAsync();
        }
        public async Task<Course> GetByIdAsync(Guid Id)
        {
            return await _commonContext.GetByIdAsync(Id);
        }
        public async Task<IEnumerable<Course>> GetByLevelAsync(Level level)
        {
            return await _context.Courses.Where(x => x.Level == level /*&& x.Categories.Any(y => y.Name.Contains("Filosofía"))*/).ToListAsync();
        }
        public async Task<Course> GetByNameAsync(string CourseName)
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
        {
            return await _commonContext.DeleteAsync(Id);
        }
    }
}
