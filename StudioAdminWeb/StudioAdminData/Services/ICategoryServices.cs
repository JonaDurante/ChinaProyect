using StudioAdminData.Models.DataModels;

namespace StudioAdminData.Services
{
    public interface ICategoryServices
    {
        public Category GetCategoryByName(string CategoryName);
    }
}