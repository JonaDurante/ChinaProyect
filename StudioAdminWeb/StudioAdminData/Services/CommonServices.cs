using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudioAdminData.DataAccess;
using StudioAdminData.Interfaces;
using StudioAdminData.Models.Abstract;

namespace StudioAdminData.Services
{
    public class CommonServices<T> : ICommonServices<T> where T : BaseEntity
    {
        private readonly StudioAdminDBContext _context;
        private readonly ILogger<ActivityServices> _logger;
        public CommonServices(StudioAdminDBContext context, ILogger<ActivityServices> logger)
        {
            _context = context;
            _logger = logger;
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
            catch (DbUpdateException ex)
            {
                // Manejar la excepción específica de DbUpdateException aquí
                _logger.LogError(ex, $"Error al intentar Insertar un {typeof(T)} ya existente");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al intentar Insertar {typeof(T)}");
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
            catch (DbUpdateException ex)
            {
                // Manejar la excepción específica de DbUpdateException aquí
                _logger.LogError(ex, $"Error al intentar Actualizar {typeof(T)} no existente");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al intentar Actualizar {typeof(T)}");
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
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al intentar Eliminar {typeof(T)}");
                return false;
            }

        }
    }
}
