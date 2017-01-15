using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseManager.Core.Models;
using CourseManager.Infrastructure.Repositories;
using CourseManager.Infrastructure;

namespace CourseManager.Web.Services
{
    public class CourseService : ICourseService
    {
        CourseRepository courserepo;
        DbManager projectdatabase;
        public CourseService()
        {
            projectdatabase = new DbManager();
            courserepo = new CourseRepository(projectdatabase); 
        }
      
        public Course GetCourseByTitle(String Title)
        {
            return courserepo.FindByTitle(Title);
        }

       
    }
}
