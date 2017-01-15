using CourseManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseManager.Core.Repositories.Interfaces;

namespace CourseManager.Infrastructure.Repositories
{
    public class SeminarRepository : Repository<Seminar>, ISeminarRepository
    {
        public SeminarRepository(DbManager platformManagement) : base(platformManagement)
        {
        }
    }
}
