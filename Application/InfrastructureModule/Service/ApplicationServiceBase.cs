using Application.SecurityModule.Contract;
using CommonServiceLocator;
using Domain.SecurityModule.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InfrastructureModule.Service
{
    public abstract class ApplicationServiceBase
    {
        public readonly IAuditAppService _auditAppService;

        public ApplicationServiceBase()
        {
            _auditAppService = ServiceLocator.Current.GetInstance<IAuditAppService>();
        }

        protected void RegisterAudit(EnumPermision permision, EnumObjectType scopeType, string principalCallMethod)
        {
            string methodCall = this.GetType().ToString() + ": RegisterAudit";
            _auditAppService.RegisterAudit(permision, scopeType, principalCallMethod, methodCall, null);
        }
    }
}
