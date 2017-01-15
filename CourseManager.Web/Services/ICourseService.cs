using CourseManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Web.Services
{
    public interface ICourseService
    {
        Course GetCourseByTitle(String title);
    }
}
