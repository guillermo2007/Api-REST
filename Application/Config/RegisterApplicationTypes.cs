using Application.SecurityModule.Contract;
using Application.SecurityModule.Handlers;
using Application.SecurityModule.Service;
using Application.UserModule;
using Application.UserModule.Interfaces;
using DAL;
using Repository.UserModule;
using Repository.UserModule.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.PolicyInjection;
using Unity.Lifetime;

namespace Services.Config
{
    public static class RegisterApplicationTypes
    {
        public static void ConfigureUnity(IUnityContainer container)
        {

            container.AddNewExtension<Interception>();

            #region AppService            
            container.RegisterType<IUserAppService, UserAppService>(new ContainerControlledLifetimeManager(),
                                        new InterceptionBehavior<PolicyInjectionBehavior>(),
                                        new Interceptor<InterfaceInterceptor>());
        
            container.RegisterType<IAuditAppService, AuditAppService>(new ContainerControlledLifetimeManager(),
                                        new InterceptionBehavior<PolicyInjectionBehavior>(),
                                        new Interceptor<InterfaceInterceptor>());

            #endregion

            #region Repositories

            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());

            #endregion


            #region DbContext

            container.RegisterType<IMainDbContext, MainDbContext>();

            #endregion            
        }
    }
}
