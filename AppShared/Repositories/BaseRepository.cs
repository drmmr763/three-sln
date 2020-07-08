using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppShared.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppShared.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly EntityContext _context;
        private DbSet<T> entities;
        
        public BaseRepository(EntityContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll() => entities.AsEnumerable();

        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entities.Add(entity);
            _context.SaveChanges();
        }
        
        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _context.SaveChanges();
        }
    }
}