using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Core.Models
{
    public class Seminar : Base
    {   
        [Required]
        [StringLength(256)]
        public string Title{ get; set; }

        [StringLength(512)]
        public string Description { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual Course Course { get; set; }
    }
}
