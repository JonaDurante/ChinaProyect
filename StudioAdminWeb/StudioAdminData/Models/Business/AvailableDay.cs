using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudioAdminData.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudioAdminData.Models.Business
{
    public class AvailableDay : BaseEntity
    {
        [Required]
        public DateTime Date { get; set; }
    }
}
