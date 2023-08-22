using StudioAdminData.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioAdminData.Interfaces
{
    public interface IActivityService
    {
        Task<IEnumerable<Activity>> GetAllAsync();
        Task<Activity> GetByIdAsync(Guid id);
        Task<IEnumerable<Activity>> GetByRollAsync(Roles rol);
        Task<bool> UpdateAsync(Activity activity);
        Task<bool> InsertAsync(Activity activity);
        Task<bool> DeleteAsync(Guid Id);
    }
}
