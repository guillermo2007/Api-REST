using Application.SecurityModule.Contract;
using Application.SecurityModule.Service;
using CommonServiceLocator;
using Domain.SecurityModule.Enum;
using System.Collections.Generic;
using Unity.Interception.PolicyInjection.Pipeline;

namespace Application.SecurityModule.Handlers
{
    class AuditCallHandler : ICallHandler
    {
        private EnumPermision Permision;
        private EnumObjectType ObjectType;

        public int Order { get; set; }

        private IAuditAppService AuditAppService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IAuditAppService>();
            }
        }

        //public AuditCallHandler(EnumPermision permision, EnumObjectType objectType)
        //{
        //    Permision = permision;
        //    ObjectType = objectType;
        //}        

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            var returnValue = getNext()(input, getNext);

            var method = input.MethodBase.DeclaringType.Name + "." + input.MethodBase.Name;
            var paramsMethod = GetParams(input);

            AuditAppService.RegisterAudit(EnumPermision.Read, EnumObjectType.User, method, paramsMethod);

            return returnValue;
        }

        private string GetParams(IMethodInvocation input)
        {
            string paramsCallMethod = "{";
            for (int i = 0; i < input.Arguments.Count; ++i)
            {
                paramsCallMethod += input.Arguments.GetParameterInfo(i).Name + ": " + input.Arguments[i];
                if ((i + 1) < input.Arguments.Count)
                {
                    paramsCallMethod += " , ";
                }

            }
            return paramsCallMethod + "}";                        
        }
        
    }
}
    