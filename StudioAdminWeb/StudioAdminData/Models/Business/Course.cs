using Microsoft.EntityFrameworkCore;
using StudioAdminData.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudioAdminData.Models.Business
{

    public class Course : BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        [ForeignKey("AvailableDayId")]
        public List<AvailableDay> Date { get; set; } = new List<AvailableDay>();
        [Required]
        public Level Level { get; set; } = Level.Basic;
    }
}
