using Domain.SecurityModule.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SecurityModule.Contract
{
    public interface IAuditAppService
    {
        void RegisterAudit(EnumPermision permision, EnumObjectType scopeType, string principalCallMethod, string callMethod, string parametersMethod, Exception noAuthorizedException = null);
    }
}
