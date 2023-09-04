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
        public decimal Payment { get; set; } //--> Courses.length == Quantity then * Value from Activity
        [Required]
        public DateTime LastPayment { get; set; }
        [Required]
        public DateTime DateOfBirthday { get; set; } = DateTime.MinValue;
        [Required]
        [ForeignKey("AvailableDayId")]
        public List<AvailableDay> Date { get; set; } = new List<AvailableDay>();
        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; } = new User();
    }
}
