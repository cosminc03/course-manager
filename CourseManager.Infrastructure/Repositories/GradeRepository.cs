using CourseManager.Core.Models;
using CourseManager.Core.Repositories.Interfaces;
namespace CourseManager.Infrastructure.Repositories
{
    public class GradeRepository : Repository<Grade>, IGradeRepository
    {
        public GradeRepository(DbManager platformManagement) : base(platformManagement)
        {
        }
    }
}