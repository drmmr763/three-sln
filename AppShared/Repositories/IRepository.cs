using AppShared.Entities;
using System;
using System.Collections.Generic;

namespace AppShared.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
    }
}