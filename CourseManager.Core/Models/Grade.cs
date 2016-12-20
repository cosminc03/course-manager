using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManager.Core.Models
{
    public class Grade : Base
    {
        public float Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Guid StudentId { get; set; }
        public virtual User Student { get; set; }

        public Guid TeacherId { get; set; }
        public virtual User Teacher { get; set; }
    }
}
