using StudioAdminData.Models.Abstract;
using System.ComponentModel.DataAnnotations;

namespace StudioAdminData.Models.Business
{
    public class User : BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required, StringLength(100)]
        public string LastName { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public Roles Roles { get; set; } = Roles.User;
    }
}
