using System;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Core.Models
{
    public class Course
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }
    }

}
