using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManager.Core.Models
{
    public class Grade : Base
    {   
        [Required]
        [Range(1.0,10.0)]
        public float Value { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual Student Student { get; set; }
        public virtual Employee Teacher { get; set; }
        public virtual Course Course { get; set; }
    }
}
