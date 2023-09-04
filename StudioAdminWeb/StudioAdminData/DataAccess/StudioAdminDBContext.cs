using Microsoft.EntityFrameworkCore;
using StudioAdminData.Models.Abstract;
using StudioAdminData.Models.Business;

namespace StudioAdminData.DataAcces
{
    public class StudioAdminDBContext : DbContext
    {
        public StudioAdminDBContext(DbContextOptions <StudioAdminDBContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AvailableDay>()
                .HasIndex(c => c.Date) // Crear un índice en la columna Date
                .IsUnique(); // Especificar que debe ser único
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<AvailableDay> AvailableDays { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Third> Thirds { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
