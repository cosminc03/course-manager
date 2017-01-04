using System;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Core.Models
{
    public abstract class Base
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid BaseId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; } 
    }
}
