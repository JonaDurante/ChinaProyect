using System.ComponentModel.DataAnnotations;

namespace StudioAdminData.Models.DataModels
{
    public class UserLoggin
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
