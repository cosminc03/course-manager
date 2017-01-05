using System.Collections.Generic;

namespace CourseManager.Core.Models
{
    public class Course : Base
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
        }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Semester { get; set; }
        public string Description { get; set; }

        public virtual Employee Owner { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
