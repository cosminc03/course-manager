using System;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Core.Models
{
    public abstract class Base
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
    }
}
