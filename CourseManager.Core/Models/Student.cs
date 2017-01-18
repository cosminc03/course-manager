using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Core.Models
{
    public class Student : Base
    {
        [Required]
        public Guid BaseId { get; set; }

        [Required]
        [StringLength(256)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(256)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Range(1,3)]
        public int CurrentYear { get; set; }

        [Required]
        public string Group { get; set; }

        public virtual ICollection<Grade> Grades { get; set; } = new HashSet<Grade>();
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
    }
}
