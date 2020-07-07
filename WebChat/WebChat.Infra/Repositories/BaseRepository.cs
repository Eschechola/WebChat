using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebChat.Domain.Entities;
using WebChat.Infra.Data.Context;
using WebChat.Infra.Interfaces;

namespace WebChat.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T: Base
    {

        private readonly ChatDataContext _context;

        public BaseRepository(ChatDataContext context)
        {
            _context = context;
        }

        public virtual T Save(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();

            return obj;
        }

        public virtual T Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
        }


        public virtual void Delete(int id)
        {
            var obj = Get(id);

            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
        }

        public virtual T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual IList<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
    }
}
