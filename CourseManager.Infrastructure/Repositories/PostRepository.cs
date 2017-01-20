using CourseManager.Core.Models;
using System.Linq;
using CourseManager.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CourseManager.Infrastructure.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(DbManager platformManagement) : base(platformManagement)
        {
        }

        public Employee FindOwner(Post post)
        {
            return DbManager.Posts
                .Where(p => p.Id == post.Id)
                .Include(p => p.Owner)
                .FirstOrDefault()
                .Owner;
        }

        public Course FindCourse(Post post)
        {
            return DbManager.Posts
                .Where(p => p.Id == post.Id)
                .Include(p => p.Course)
                .FirstOrDefault()
                .Course;
        }
    }
}