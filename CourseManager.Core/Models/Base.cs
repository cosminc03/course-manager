using System;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Core.Models
{
    public abstract class Base
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}
