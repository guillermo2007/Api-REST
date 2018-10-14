using Domain;
using System.Data.Entity;

namespace DAL
{
    public interface IMainDbContext
    {
        IDbSet<T> Set<T>() where T : EntityBase;
        int SaveChanges();
    }
}
