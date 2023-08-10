using StudioAdminData.DataAcces;
using StudioAdminData.Models.DataModels;

namespace StudioAdminData.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly StudioAdminDBContext _context;

        public CategoryServices(StudioAdminDBContext context)
        {
            _context = context;
        }

        public Category GetCategoryByName(string CategoryName) {

            return _context.Categories.Where(x => x.Name == CategoryName).FirstOrDefault();
        }

    }
}
