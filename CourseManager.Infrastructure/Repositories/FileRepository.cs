using CourseManager.Core.Models;
using CourseManager.Core.Repositories.Interfaces;
namespace CourseManager.Infrastructure.Repositories
{
    public class FileRepository : Repository<File>, IFileRepository
    {
        public FileRepository(DbManager platformManagement) : base(platformManagement)
        {
        }
    }
}