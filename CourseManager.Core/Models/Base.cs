﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Core.Models
{
    public abstract class Base
    {
        [Required]
        public Guid Id { get; set; }
    }
}
