using System;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Core.Models
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
