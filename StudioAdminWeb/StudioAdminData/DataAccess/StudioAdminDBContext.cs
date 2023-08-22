using Microsoft.EntityFrameworkCore;
<<<<<<< Updated upstream
using StudioAdminData.Models.DataModels.Business;
=======
using StudioAdminData.Models.Abstract;
using StudioAdminData.Models.Business;
>>>>>>> Stashed changes

namespace StudioAdminData.DataAcces
{
    public class StudioAdminDBContext : DbContext
    {
        public StudioAdminDBContext(DbContextOptions <StudioAdminDBContext> options) : base(options)
        {
            
        }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Third> Thirds { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
