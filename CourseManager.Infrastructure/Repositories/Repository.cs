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
        protected readonly DbManager Context;

        protected Repository(DbManager dbMang)
        {
            Context = dbMang;
        }

        public T Create(T p)
        {
            Context.Add(p);
            Context.SaveChanges();
            return p;
        }

        public void Update(T p)
        {
            Context.Update(p);
            Context.SaveChanges();
        }

        public void Delete(T p)
        {
            Context.Remove(p);
            Context.SaveChanges();
        }

        public T FindById(Guid id)
        {
            var queryResult = from elem in Context.Set<T>()
                              where elem.Id == id
                              select elem;
            return queryResult.FirstOrDefault();
        }

        public IEnumerable<T> FindAll()
        {
            var queryResult = from elem in Context.Set<T>()
                              select elem;
            return queryResult;
        }
    }
}
