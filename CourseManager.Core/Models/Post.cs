using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Core.Models
{
    public class Post : Base
    {
        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    
        public virtual Employee Owner { get; set; }
        public virtual Course Course { get; set; }
    }
}
