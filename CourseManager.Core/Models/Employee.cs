using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Core.Models
{
    public class Employee : BaseUser
    {
        public Employee()
        {
            this.Posts = new HashSet<Post>();
            this.Courses = new HashSet<Course>();
            this.Files = new HashSet<File>();
        }
        
        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<File> Files { get; set; }

    }
}
