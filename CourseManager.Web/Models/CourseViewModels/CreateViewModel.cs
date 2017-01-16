using System.ComponentModel.DataAnnotations;

namespace CourseManager.Web.Models.CourseViewModels
{
    public class CreateViewModel
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
