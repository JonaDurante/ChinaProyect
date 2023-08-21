using StudioAdminData.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioAdminData.Interfaces
{
    public interface IActivityValueService
    {
        Task<IEnumerable<ActivityValue>> GetAllValuesAsync();
        Task<ActivityValue> GetActivityValueAsync(int quantity);
        Task<(IEnumerable<int>, IEnumerable<decimal>)> GetByRollAsync(Third third);
        Task<bool> UpdateAsync(ActivityValue activityValue);
        Task<bool> InsertAsync(ActivityValue activityValue);
        Task<bool> DeletAsync(int ActivityQuantity);
    }
}
