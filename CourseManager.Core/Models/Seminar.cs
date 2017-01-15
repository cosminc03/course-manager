using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Core.Models
{
    public class Seminar : Base
    {
        public Guid CourseId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String Content { get; set; }
        public virtual File Document {get; set;}

        public virtual Course BaseCourse { get; set; }
        

    }
}
