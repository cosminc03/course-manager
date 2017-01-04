using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Core.Models
{
    public class Employee : Base
    {
        public Employee()
        {
            this.Posts = new HashSet<Post>();
        }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
