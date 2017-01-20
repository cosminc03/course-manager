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
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IStudentRepository _studentRepository;

        public PostService(
            IPostRepository postRepository,
            IEmployeeRepository employeeRepository,
            IStudentRepository studentRepository
            )
        {
            _postRepository = postRepository;
            _employeeRepository = employeeRepository;
            _studentRepository = studentRepository;
        }

        public void CreatePost(Post post)
        {
            _postRepository.Create(post);
        }

        public Post GetPostById(Guid guid)
        {
            return _postRepository.FindById(guid);
        }

        public void UpdatePost(Post post)
        {
            _postRepository.Update(post);
        }
        public void DeletePost(Post post)
        {
            _postRepository.Delete(post);
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _postRepository.FindAll();
        }

        public Employee GetPostOwner(Post post)
        {
            return _postRepository.FindOwner(post);
        }

        public Course GetPostCourse(Post post)
        {
            return _postRepository.FindCourse(post);
        }
    }
}
