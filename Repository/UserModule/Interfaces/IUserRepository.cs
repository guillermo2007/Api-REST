using Domain.UserModule.Aggregates;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UserModule.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
    }
}
