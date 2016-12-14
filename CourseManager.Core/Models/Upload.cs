using System;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Core.Models
{
    public class Upload
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime UploadedAt { get; set; }
    }
}
