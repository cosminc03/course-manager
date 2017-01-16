using System;
using System.Linq;
using System.Collections.Generic;
using CourseManager.Core.Models;
using CourseManager.Core.Repositories.Interfaces;

namespace CourseManager.Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T>
        where T : Base
    {
        protected readonly DbManager DbManager;

        protected Repository(DbManager dbManager)
        {
            DbManager = dbManager;
        }

        public T Create(T p)
        {
            DbManager.Add(p);
            DbManager.SaveChanges();
            return p;
        }

        public void Update(T p)
        {
            DbManager.Update(p);
            DbManager.SaveChanges();
        }

        public void Delete(T p)
        {
            DbManager.Remove(p);
            DbManager.SaveChanges();
        }

        public T FindById(Guid id)
        {
            var queryResult = from elem in DbManager.Set<T>()
                              where elem.Id == id
                              select elem;
            return queryResult.FirstOrDefault();
        }

        public IEnumerable<T> FindAll()
        {
            var queryResult = from elem in DbManager.Set<T>()
                              select elem;
            return queryResult;
        }
    }
}
