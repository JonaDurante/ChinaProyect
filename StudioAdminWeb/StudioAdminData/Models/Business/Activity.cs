using StudioAdminData.Models.Abstract;
using System.ComponentModel.DataAnnotations;

namespace StudioAdminData.Models.Business
{
    public class Activity : BaseEntity
    {
        [Required]
        public int Quantity { get; set; } = 0;
        [Required]
        public Roles Roles { get; set; } = 0;
        [Required]
        public decimal Value { get; set; } = 0.00M;

    }
}
