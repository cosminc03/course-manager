using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManager.Core.Models
{
    public class Student : Base
    {
        public Student()
        {
            this.Grades = new HashSet<Grade>();
        }
       
        public int CurrentYear { get; set; }
        public string Group { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }        
    }
}
