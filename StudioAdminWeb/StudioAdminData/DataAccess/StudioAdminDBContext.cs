using Microsoft.EntityFrameworkCore;
using StudioAdminData.Models.Business;

namespace StudioAdminData.DataAcces
{
    public class StudioAdminDBContext : DbContext
    {
        public StudioAdminDBContext(DbContextOptions <StudioAdminDBContext> options) : base(options)
        {
            
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<ActivityValue>(entity =>
        //    {
        //        entity.HasNoKey();

        //    });

        //    // Aquí puedes agregar más configuraciones de entidades, relaciones, índices, etc.
        //}

        public DbSet<ActivityValue> ActivityValues { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Third> Thirds { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
