using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Core.Models
{
    public class Course : Base
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
        }

        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        [Required]
        [Range(1,3)]
        public int Year { get; set; }

        [Required]
        [Range(1,2)]
        public int Semester { get; set; }

        [StringLength(512)]
        public string Description { get; set; }

        public virtual Employee Owner { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
