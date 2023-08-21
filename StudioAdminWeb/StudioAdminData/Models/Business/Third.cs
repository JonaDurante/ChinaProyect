using StudioAdminData.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudioAdminData.Models.Business
{
    public class Third : BaseEntity // Profesor como Alumne
    {
        [Required]
        public Level Level { get; set; } = Level.Basic;
        [Required]
        public decimal Payment { get; set; } = 0.00M; //--> Courses.length == Quantity then * StudenValue from ActivityValue
        [Required]
        public DateTime LastPayment { get; set; } = DateTime.MinValue;
        [Required]
        public DateTime DateOfBirthday { get; set; } = DateTime.MinValue;
        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; } = new User();
        [Required]
        [ForeignKey("CourseId")]
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
