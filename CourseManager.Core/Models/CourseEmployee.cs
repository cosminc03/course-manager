using System;

namespace CourseManager.Core.Models
{
    public class CourseEmployee
    {
        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
