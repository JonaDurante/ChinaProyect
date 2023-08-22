namespace StudioAdminData.Interfaces
{
    public interface ICommonServices<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<bool> InsertAsync(T Entity);
        Task<bool> UpdateAsync(T Entity);
        Task<bool> DeleteAsync(Guid Id);
    }
}