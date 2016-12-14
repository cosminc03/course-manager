using System;
using System.Collections.Generic;

namespace CourseManager.Core.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T obj);
        void Edit(T obj);
        void Delete(T obj);
        IEnumerable<T> FindById(Guid id);
        IEnumerable<T> FindAll();
    }
}
