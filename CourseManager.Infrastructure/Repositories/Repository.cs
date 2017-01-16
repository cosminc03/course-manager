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
        protected readonly DbManager _dbManager;

        protected Repository(DbManager dbManager)
        {
            _dbManager = dbManager;
        }

        public T Create(T p)
        {
            _dbManager.Add(p);
            _dbManager.SaveChanges();
            return p;
        }

        public void Update(T p)
        {
            _dbManager.Update(p);
            _dbManager.SaveChanges();
        }

        public void Delete(T p)
        {
            _dbManager.Remove(p);
            _dbManager.SaveChanges();
        }

        public T FindById(Guid id)
        {
            var queryResult = from elem in _dbManager.Set<T>()
                              where elem.Id == id
                              select elem;
            return queryResult.FirstOrDefault();
        }

        public IEnumerable<T> FindAll()
        {
            var queryResult = from elem in _dbManager.Set<T>()
                              select elem;
            return queryResult;
        }
    }
}
