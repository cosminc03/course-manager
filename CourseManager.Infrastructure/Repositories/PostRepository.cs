using CourseManager.Core.Models;
using CourseManager.Core.Repositories.Interfaces;
namespace CourseManager.Infrastructure.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(DbManager platformManagement) : base(platformManagement)
        {
        }
    }
}