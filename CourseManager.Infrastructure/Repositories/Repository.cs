using System;
using System.Collections.Generic;
using CourseManager.Core.Repositories.Interfaces;

namespace CourseManager.Infrastructure.Repositories
{
    public abstract class Repository<T>: IRepository<T>
        where T:class
    {
        protected readonly DatabaseManagement context;

        public Repository(DatabaseManagement dm)
        {
            context = dm;
        }
        public void Create(T p)
        {
            context.Add(p);
            context.SaveChanges();
        }

        public void Edit(T obj)
        {

        }
        public void Delete(T obj)
        {

        }

        public IEnumerable<T> FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
