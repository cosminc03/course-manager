using CourseManager.Core.Models;

namespace CourseManager.Core.Repositories.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        Employee FindOwner(Post post);

        Course FindCourse(Post post);
    }
}
