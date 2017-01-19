using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CourseManager.Web.Models.CourseViewModels
{
    public class CourseAddAssociateViewModel
    {
        [Required]
        public string Associate { get; set; }
        public SelectList AssociateList { get; set; }
    }
}
