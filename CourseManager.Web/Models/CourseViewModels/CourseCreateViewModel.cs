using System;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Web.Models.CourseViewModels
{
    public class CourseCreateViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Semester { get; set; }

        [Required]
        public string Description { get; set; }

        public Guid Id { get; set; }
    }
}
