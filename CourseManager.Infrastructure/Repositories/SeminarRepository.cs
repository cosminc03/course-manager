using CourseManager.Core.Models;
using CourseManager.Core.Repositories.Interfaces;

namespace CourseManager.Infrastructure.Repositories
{
    public class SeminarRepository: Repository<Seminar>, ISeminarRepository
    {
        public SeminarRepository(DbManager platformManagement) : base(platformManagement)
        {

        }
    }
}
