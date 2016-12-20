using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManager.Core.Models
{
    public class User : Base
    {
        public User()
        {
            this.Grades = new List<Grade>();
            this.Posts = new List<Post>();
        }
        public Guid BaseId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CurrentYear { get; set; }
        public string Group { get; set; }

        [InverseProperty("Student")]
        public virtual List<Grade> Grades { get; set; }

        [InverseProperty("User")]
        public virtual List<Post> Posts { get; set; }
    }
}
