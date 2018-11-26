using Application.SecurityModule.Contract;
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
using Unity.Lifetime;

namespace Services.Config
{
    public static class RegisterApplicationTypes
    {
        public static void ConfigureUnity(IUnityContainer container)
        {
            #region AppService

            container.RegisterType<IUserAppService, UserAppService>(new HierarchicalLifetimeManager());
            container.RegisterType<IAuditAppService, AuditAppService>(new HierarchicalLifetimeManager());

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
