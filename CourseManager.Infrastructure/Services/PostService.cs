using CourseManager.Core.Services.Interfaces;
using CourseManager.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseManager.Core.Models;
using CourseManager.Core.Repositories.Interfaces;

namespace CourseManager.Infrastructure.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public void CreatePost(Post post)
        {
            _postRepository.Create(post);
        }

        public void DeletePost(Post post)
        {
            _postRepository.Delete(post);
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _postRepository.FindAll();
        }

        public IEnumerable<string> GetAllPostsNames()
        {
            throw new NotImplementedException();
        }

        public Post GetPostsById(Guid guid)
        {
            return _postRepository.FindById(guid);
        }

        public void UpdatePost(Post post)
        {
            _postRepository.Update(post);
        }
    }
}
