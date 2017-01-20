using CourseManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Core.Services.Interfaces
{
    public interface IPostService
    {
        void CreatePost(Post post);

        Post GetPostById(Guid guid);
        
        void UpdatePost(Post post);

        void DeletePost(Post post);

        IEnumerable<Post> GetAllPosts();

        Employee GetPostOwner(Post post);

        Course GetPostCourse(Post post);
    }
}
