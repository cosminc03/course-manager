using System;

namespace CourseManager.Core.Models
{
    public class StudentCourse
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}
