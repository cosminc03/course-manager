using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Core.Models
{
    public class Employee : Base
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

        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
        public virtual ICollection<File> Files { get; set; } = new HashSet<File>();
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
        //public virtual ICollection<CourseEmployee> CourseEmployees { get; set; } = new HashSet<CourseEmployee>();
    }
}
