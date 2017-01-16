using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Web.Models.SeminarViewModels
{
    public class CreateSeminarViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
    }
}
