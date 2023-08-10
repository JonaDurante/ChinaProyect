using Microsoft.EntityFrameworkCore;
using StudioAdminData.Models.DataModels;

namespace StudioAdminData.DataAcces
{
    public class StudioAdminDBContext : DbContext
    {
        public StudioAdminDBContext(DbContextOptions <StudioAdminDBContext> options) : base(options)
        {
            
        }

        //ToDo: Add DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}
