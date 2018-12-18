using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using Unity.Lifetime;

namespace WebApi.Config
{
    public class UnityServiceLocator : ServiceLocatorImplBase, IDisposable
    {
        private IUnityContainer _container;

        public UnityServiceLocator(IUnityContainer container)
        {
            _container = container;
            container.RegisterInstance<IServiceLocator>(this, new HierarchicalLifetimeManager());
        }

        public void Dispose()
        {
            if (_container != null)
            {
                _container.Dispose();
                _container = null;
            }
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            if (_container == null) throw new ObjectDisposedException("container");
            return _container.Resolve(serviceType, key);
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            if (_container == null) throw new ObjectDisposedException("container");
            return _container.ResolveAll(serviceType);
        }
    }
}