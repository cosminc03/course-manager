using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CourseManager.Web.Models.PostViewModels
{
    public class PostCreateViewModel
    {
        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string Course { get; set; }
        public SelectList CourseList { get; set; }
    }
}
