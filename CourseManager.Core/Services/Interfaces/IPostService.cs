using CourseManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Core.Services.Interfaces
{
    public interface IPostService
    {
        IEnumerable<Post> GetAllPosts();

        IEnumerable<string> GetAllPostsNames();

        Post GetPostsById(Guid guid);

        void CreatePost(Post post);
        void UpdatePost(Post post);
        void DeletePost(Post post);
    }
}
