using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseManager.Core.Models;
using CourseManager.Core.Repositories.Interfaces;
namespace CourseManager.Infrastructure.Repositories
{
    public class UserRepository : Repository<Student>, IUserRepository
    {
        public UserRepository(DbManager platformManagement) : base(platformManagement)
        {
        }
    }
}