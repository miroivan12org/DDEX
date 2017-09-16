using MusiUploaderWeb.Interfaces;
using MusiUploaderWeb.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusiUploaderWeb.Models.Repository
{
    public abstract class GenericRepository<C, T> : IGenericRepository<T> where T : class where C : DbContext, new()
    {
        private C _entities = new C();
        public C Context
        {
            get { return _entities; }
            set { _entities = value; }
        }

        public virtual IEnumerable<T> GetAll()
        {
            IEnumerable<T> query = _entities.Set<T>();
            return query;
        }

        public virtual void Add(T entity)
        {
            _entities.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}