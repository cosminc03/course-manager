using System;

namespace CourseManager.Core.Models
{
    public class File : Base
    {
        public DateTime UploadDateTime { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public int FileSize { get; set; }
        public string FilePath { get; set; }
        public virtual Student Owner { get; set; }
    }
}
