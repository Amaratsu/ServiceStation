using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using ServiceStation.Infrastructure.Abstract;
using ServiceStation.Infrastructure.Concrete;

namespace ServiceStation.Infrastructure
{
    internal class NinjectDependecyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependecyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        public NinjectDependecyResolver(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}