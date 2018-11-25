using Application.SecurityModule.Contract;
using Domain.SecurityModule.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SecurityModule.Service
{
    public class AuditAppService : IAuditAppService
    {
        //public void RegisterAudit(EnumPermision permision, EnumObjectType scopeType, string principalCallMethod, string callMethod, string parametersMethod, IAuditable objectAudit, Exception noAuthorizedException = null)
        public void RegisterAudit(EnumPermision permision, EnumObjectType scopeType, string principalCallMethod, string callMethod, string parametersMethod, Exception noAuthorizedException = null)
        {
            throw new NotImplementedException();
        }
    }
}
