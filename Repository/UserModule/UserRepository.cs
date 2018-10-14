using DAL;
using Domain.UserModule.Aggregates;
using Repository.Base;
using Repository.UserModule.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UserModule
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IMainDbContext context) : base (context)
        {

        }
    }
}
