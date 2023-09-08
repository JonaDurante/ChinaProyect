using StudioAdminData.DataAccess;
using StudioAdminData.Interfaces;
using StudioAdminData.Models.Business;

namespace StudioAdminData.Services
{
    public class AvailableDayServices
    {
        private readonly ICommonServices<AvailableDay> _commonContext;
        public AvailableDayServices(StudioAdminDBContext context, ICommonServices<AvailableDay> commonContext)
        {
            _commonContext = commonContext;
        }

        public async Task<IEnumerable<AvailableDay>> GetAllAsync()
        {
            return await _commonContext.GetAllAsync();
        }
        public async Task<AvailableDay> GetByIdAsync(Guid Id)
        {
            return await _commonContext.GetByIdAsync(Id);
        }
        public async Task<bool> InsertAsync(AvailableDay course)
        {
            return await _commonContext.InsertAsync(course);
        }
        public async Task<bool> UpdateAsync(AvailableDay course)
        {
            return await _commonContext.UpdateAsync(course);
        }
        public async Task<bool> DeleteAsync(Guid Id)
        {
            return await _commonContext.DeleteAsync(Id);
        }
    }
}
