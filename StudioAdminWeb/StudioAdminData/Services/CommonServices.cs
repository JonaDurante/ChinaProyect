using Microsoft.EntityFrameworkCore;
using StudioAdminData.DataAcces;
using StudioAdminData.Interfaces;
using StudioAdminData.Models.Abstract;

namespace StudioAdminData.Services
{
    public class CommonServices<T> : ICommonServices<T> where T : BaseEntity
    {
        private readonly StudioAdminDBContext _context;
        public CommonServices(StudioAdminDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync() 
        {
            var Entity = await _context.Set<T>().ToListAsync();
            return Entity;
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().Where(a => a.Id == id).FirstAsync();
        }
        public async Task<bool> InsertAsync(T Entity)
        {
            var resultado = false;
            try
            {
                if (Entity != null)
                {
                    _context.Add(Entity);
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
        public async Task<bool> UpdateAsync(T Entity)
        {
            _context.Entry(Entity).State = EntityState.Modified;
            var result = false;
            try
            {
                result = await _context.SaveChangesAsync() > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                //guardar en db

            }
            return result;
        }
        public async Task<bool> DeleteAsync(Guid Id)
        {
            try
            {
                var Entity = await GetByIdAsync(Id);
                if (Entity == null)
                {
                    return false;
                }
                _context.Set<T>().Remove(Entity);
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
