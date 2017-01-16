using CourseManager.Core.Models;
using CourseManager.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Infrastructure.Repositories
{
    public class SeminarRepository: Repository<Seminar>, ISeminarRepository
    {
        public SeminarRepository(DbManager platformManagement) : base(platformManagement)
        {

        }
    }
}
