using StudioAdminData.DataAcces;
using StudioAdminData.Interfaces;
using StudioAdminData.Models.Business;

namespace StudioAdminData.Services
{
    public class ThirdServices : IThirdServices
    {
        private readonly StudioAdminDBContext _context;
        private readonly ICommonServices<Third> _commonContext;

        public ThirdServices(StudioAdminDBContext context, ICommonServices<Third> commonContext)
        {
            _context = context;
            _commonContext = commonContext;
        }

        public async Task<IEnumerable<Third>> GetAllAsync()
        {
            return await _commonContext.GetAllAsync();
        }
        public async Task<Third> GetByIdAsync(Guid Id)
        {
            return await _commonContext.GetByIdAsync(Id);
        }
        public IEnumerable<Third> GetByAge(int age)
        {
            var actualDate = DateTime.Today;
            return _context.Thirds.Where(x => (actualDate - x.DateOfBirthday).TotalDays / 365.25 > age).ToList();
        }
        public IEnumerable<Third> GetAllEnabledStudents()
        {
            return _context.Thirds.Where(x => x.IsDeleted == false).ToList();
        }
        public async Task<bool> InsertAsync(Third third)
        {
            return await _commonContext.InsertAsync(third);
        }
        public async Task<bool> UpdateAsync(Third third)
        {
            return await _commonContext.UpdateAsync(third);
        }
        public async Task<bool> DeleteAsync(Guid Id)
        {
            return await _commonContext.DeleteAsync(Id);
        }
    }
}
