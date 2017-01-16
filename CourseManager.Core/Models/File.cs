using System;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Core.Models
{
    public class File : Base
    {   
        [Required]
        public DateTime UploadDateTime { get; set; }

        [Required]
        [StringLength(256)]
        public string FileName { get; set; }

        [Required]
        [StringLength(256)]
        public string FileExtension { get; set; }

        public int FileSize { get; set; }

        [Required]
        public string FilePath { get; set; }

        public virtual Employee Owner { get; set; }
    }
}
