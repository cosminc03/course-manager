using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManager.Core.Models
{
    public class Student : BaseUser
    {
        public Student()
        {
            this.Grades = new HashSet<Grade>();
            this.Courses = new HashSet<Course>();
        }

        [Required]
        [Range(1,3)]
        public int CurrentYear { get; set; }

        [Required]
        public string Group { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
