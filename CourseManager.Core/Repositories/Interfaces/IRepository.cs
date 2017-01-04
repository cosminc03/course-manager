using System;
using System.Collections.Generic;

namespace CourseManager.Core.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        T Create(T obj);
        void Update(T obj);
        void Delete(T obj);
        T FindById(Guid id);
        IEnumerable<T> FindAll();
    }
}