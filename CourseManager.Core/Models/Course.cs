using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Core.Models
{
    public class Course : Base
    {
        public Course()
        {
            this.Students = new HashSet<User>();
        }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Semester { get; set; }
        public string Description { get; set; }
        public virtual User Owner { get; set; }
        public virtual ICollection<User> Students { get; set; }
    }
}
