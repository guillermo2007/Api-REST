using Domain.SecurityModule.Enum;

namespace Application.SecurityModule.Contract
{
    public interface IAuditAppService
    {
        void RegisterAudit(EnumPermision permision, EnumObjectType scopeType, string callMethod, string parametersMethod);
    }
}
