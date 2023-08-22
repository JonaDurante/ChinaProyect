using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudioAdminData.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudioAdminData.Models.Abstract
{
    public abstract class BaseEntity 
    {
        [Column(Order = 0)]
        [Required]
        [Key]
        public Guid Id { get; set; }       
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        [NotMapped] 
        public bool ShouldDeletePropertiesBeRequired => IsDeleted;

    }
}
