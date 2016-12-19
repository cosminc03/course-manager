using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Core.Models
{
    public class Post : Base
    {
        public Post()
        {
            this.Comments = new HashSet<Post>();
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual User User { get; set; }
        public virtual Post Parent { get; set; }
        public virtual ICollection<Post> Comments { get; set; }
        
    }
}
