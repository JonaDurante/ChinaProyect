using System.ComponentModel.DataAnnotations;

namespace StudioAdminData.Models.Loggin
{
    public class UserLoggin
    {
        [Required]
        public string UserMail { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
