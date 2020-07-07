using System.Collections.Generic;
using WebChat.Domain.Entities;

namespace WebChat.Infra.Interfaces
{
    public interface IBaseRepository<T> where T : Base
    {
        T Save(T obj);
        T Update(T obj);
        void Delete(int id);
        T Get(int id);
        IList<T> GetAll();
    }
}
