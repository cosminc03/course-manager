using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Core.Models
{
    public class Seminar:Base
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string Title{ get; set; }
        public string Description { get; set; }
        public string Content { get; set; }


    }
}
