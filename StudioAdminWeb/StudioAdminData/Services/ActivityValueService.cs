using Microsoft.EntityFrameworkCore;
using StudioAdminData.DataAcces;
using StudioAdminData.Interfaces;
using StudioAdminData.Models.Business;

namespace StudioAdminData.Services
{
    public class ActivityValueService : IActivityValueService
    {
        private readonly StudioAdminDBContext _context;
        public ActivityValueService(StudioAdminDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ActivityValue>> GetAllValuesAsync()
        {
            var activityValues = await _context.ActivityValues.ToListAsync();
            return activityValues;
        }
        public async Task<ActivityValue> GetActivityValueAsync(int quantity)
        {
            return await _context.ActivityValues.Where(a => a.Quantity == quantity).FirstAsync();
        }
        public async Task<(IEnumerable<int>, IEnumerable<decimal>)> GetByRollAsync(Third third) {

            var Quantity = new List<int>();
            var Value = new List<decimal>();
            var ActividyAndValue = await GetAllValuesAsync();
            Quantity.AddRange(ActividyAndValue.Select(a => a.Quantity));
            if (third.User.Roles == Roles.Medium)
            {
                Value.AddRange(ActividyAndValue.Select(d => d.ProfessorValue).ToList());
            }else 
            {
                Value.AddRange(ActividyAndValue.Select(d => d.StudenValue).ToList());
            }
            return (Quantity, Value);
        }

        public async Task<bool> UpdateAsync(ActivityValue activityValue) {
            var resultado = false;
            var ActividyAndValue = await GetActivityValueAsync(activityValue.Quantity);
            try
            {
                if (ActividyAndValue != null)
                {
                    ActividyAndValue.Quantity = activityValue.Quantity;
                    ActividyAndValue.ProfessorValue = activityValue.ProfessorValue;
                    ActividyAndValue.StudenValue = activityValue.StudenValue;
                    resultado = _context.SaveChanges() != 0;
                }
            }
            catch (Exception)
            {
                //guardar error
            }
            return resultado;
        }

        public async Task<bool> InsertAsync(ActivityValue activityValue) {
            var resultado = false;
            try
            {
                if (activityValue != null)
                {
                    _context.Add(activityValue);
                    await _context.SaveChangesAsync(); // Espera a que se complete la operación asincrónica
                    resultado = true;
                }
            }
            catch (Exception)
            {
                //guardar error
            }
            return resultado;
        }

        public async Task<bool> DeletAsync(int ActivityCode)
        {
            try
            {
                var Activity = await GetActivityValueAsync(ActivityCode);
                if (Activity == null)
                {
                    return false;
                }
                _context.ActivityValues.Remove(Activity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                //guardar error
                return false;
            }

        }
    }

}
