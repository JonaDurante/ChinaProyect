using StudioAdminData.Models.DataModels;
using StudioAdminData.DataAcces;

namespace StudioAdminData.Services
{
    public class Services : IServices
    {
        private readonly StudioAdminDBContext _context;

        public Services(StudioAdminDBContext context)
        {
            _context = context;
        }
    }
}
