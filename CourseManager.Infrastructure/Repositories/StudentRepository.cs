using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseManager.Core.Models;
using CourseManager.Core.Repositories.Interfaces;
using NuGet.Packaging;

namespace CourseManager.Infrastructure.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(DbManager dbManager) : base(dbManager)
        {

        }

        public Student FindByBaseId(Guid baseId)
        {
            var queryResult = from elem in DbManager.Set<Student>()
                              where elem.BaseId == baseId
                              select elem;
            return queryResult.FirstOrDefault();
        }
    }
}