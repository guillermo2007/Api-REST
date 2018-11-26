using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Base
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        T Get(Guid id);
        IEnumerable<T> GetAll();
        T Add(T entity);
        T Update(T entity);
        void Delete(Guid id);
        void Delete(T entity);
    }
}
