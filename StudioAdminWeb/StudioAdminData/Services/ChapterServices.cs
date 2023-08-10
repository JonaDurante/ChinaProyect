using StudioAdminData.DataAcces;
using StudioAdminData.Models.DataModels;

namespace StudioAdminData.Services
{
    public class ChapterServices : IChapterServices
    {
        private readonly StudioAdminDBContext _context;
        private readonly ICourseServices _courseServices;

        public ChapterServices(StudioAdminDBContext context, ICourseServices courseServices)
        {
            _context = context;
            _courseServices = courseServices;
        }
    }
}
