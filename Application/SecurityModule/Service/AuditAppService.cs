using Application.SecurityModule.Contract;
using Domain.SecurityModule.Aggregates;
using Domain.SecurityModule.Enum;
using Repository.SecurityModule.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SecurityModule.Service
{
    public class AuditAppService : IAuditAppService
    {
        private ILogActionRepository _logActionRepository;

        public AuditAppService(ILogActionRepository logActionRepository)
        {
            _logActionRepository = logActionRepository;
        }

        public void RegisterAudit(EnumPermision permision, EnumObjectType scopeType, string callMethod, string parametersMethod)
        {
            var data = callMethod + " | " + parametersMethod;
            var logAction = new LogAction(permision.ToString(), scopeType.ToString(), data);
            _logActionRepository.Add(logAction);            
        }
    }
}
