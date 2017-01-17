using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Web.Models.PostViewModels
{
    public class PostCreateViewModel
    {
        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        public Guid Id { get; set; }
    }
}
