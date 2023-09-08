using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudioAdminData.Models.Business;

namespace StudioAdminData.DataAccess
{
    public class StudioAdminDBContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
        public StudioAdminDBContext(DbContextOptions<StudioAdminDBContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AvailableDay>()
                .HasIndex(c => c.Date) // Crear un índice en la columna Date
                .IsUnique(); // Especificar que debe ser único
        }

        public DbSet<Activity> Activities { get; set; } = default!;
        public DbSet<AvailableDay> AvailableDays { get; set; } = default!;
        public DbSet<Course> Courses { get; set; } = default!;
        public DbSet<Third> Thirds { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var logger = _loggerFactory.CreateLogger<StudioAdminDBContext>();
            optionsBuilder.LogTo(d => logger.Log(LogLevel.Error, d, new[] { DbLoggerCategory.Database.Name }), LogLevel.Error)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    }
}
