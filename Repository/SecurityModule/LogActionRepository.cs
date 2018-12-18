using DAL;
using Domain.SecurityModule.Aggregates;
using Repository.Base;
using Repository.SecurityModule.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SecurityModule
{
    public class LogActionRepository : RepositoryBase<LogAction>, ILogActionRepository
    {
        public LogActionRepository(IMainDbContext context) : base(context)
        {

        }
    }
}
