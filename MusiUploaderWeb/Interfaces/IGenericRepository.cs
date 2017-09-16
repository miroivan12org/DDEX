using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusiUploaderWeb.Interfaces
{
    interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
        void Save();
    }
}