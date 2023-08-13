using System.ComponentModel.DataAnnotations;

namespace StudioAdminData.Models.DataModels.Business
{
    public class ActivityValue
    {
        [Required]
        [Key]
        public int Quantity { get; set; } = 0;
        [Required]
        public decimal ProfessorValue { get; set; } = 0.00M;
        [Required]
        public decimal StudenValue { get; set; } = 0.00M;

    }
}
