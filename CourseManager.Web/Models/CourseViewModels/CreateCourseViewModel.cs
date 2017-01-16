using System.ComponentModel.DataAnnotations;

namespace CourseManager.Web.Models.CourseViewModels
{
    public class CreateCourseViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Semester { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
