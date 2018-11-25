using Domain.SecurityModule.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;
using Unity.Lifetime;

namespace Application.SecurityModule.Handlers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Method)]
    public class AuditCallHandlerAttribute : HandlerAttribute
    {
        private const string AUDITCALLHANDLERATTRIBUTE = "AuditCallHandlerAttribute";

        public EnumPermision OperationName { get; set; }
        public EnumObjectType ScopeType { get; set; }

        private static readonly object padlock = new object();

        public AuditCallHandlerAttribute(EnumPermision operationName, EnumObjectType scopeType, int order)
        {
            Order = order;
            OperationName = operationName;
            ScopeType = scopeType;
        }

        public AuditCallHandlerAttribute(EnumPermision operationName, EnumObjectType scopeType) : this(operationName, scopeType, 0)
        {

        }

        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            ICallHandler handler = null;
            var tmp = new StringBuilder();
            tmp.Append(AUDITCALLHANDLERATTRIBUTE).Append(".").Append(OperationName).Append(".").Append(ScopeType);
            var name = tmp.ToString();

            lock(padlock)
            {
                //TODO: mirar si esta registrado el container 
                //bool isRegistered = UnityControlRegister.Instance.IsRegistered(name);
                bool isRegistered = true;

                if(!isRegistered)
                {
                    handler = new AuditCallHandler(OperationName, ScopeType, Order);
                    container.RegisterInstance(name.ToString(), handler, new ContainerControlledLifetimeManager());
                    //UnityControlRegister.Instance.Register(name);
                }
                else
                {
                    handler = container.Resolve<ICallHandler>(name);
                }
            }
            return handler;
        }
    }
}
