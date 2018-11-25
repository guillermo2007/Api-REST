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
        public EnumObjectType ScopeType { get; set; }
        public EnumPermision OperationName { get; set; }
        public int Order { get; set; }

        private IAuditAppService AuditAppService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IAuditAppService>();
            }
        }

        public AuditCallHandler(EnumPermision operationName, EnumObjectType scopeType, int order)
        {
            OperationName = operationName;
            ScopeType = scopeType;
            Order = order;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            var returnValue = getNext()(input, getNext);
            var paramsCallMethodo = "{"; 

            if (returnValue.Exception == null)
            {
                var data = new List<object>();
                
                for (int i = 0; i < input.Arguments.Count; ++i)
                {
                    paramsCallMethodo += input.Arguments.GetParameterInfo(i).Name + ": " + input.Arguments[i];
                    if ((i + 1) < input.Arguments.Count)
                    {
                        paramsCallMethodo += " , ";
                    }

                }
                paramsCallMethodo = paramsCallMethodo + "}";
                data.Add(paramsCallMethodo);

            }
            else
            {
                //data.Add(contextoSeguridad.Dato);
            }

            AuditAppService.RegisterAudit(OperationName, ScopeType, GetIdCallMethod(input), "AuditCallHandler:Invoke", paramsCallMethodo, returnValue.Exception);

            return returnValue;
        }

        private string GetIdCallMethod(IMethodInvocation input)
        {
            return input.MethodBase.DeclaringType.Name + "." + input.MethodBase.Name;
        }
    }
}
    