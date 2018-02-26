namespace PropertyManagement.WebApi.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http.Dependencies;
    using Ninject;
    using Repositories.Abstract;
    using Repositories.Concrete;

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
            
        }

        private void AddBindings()
        {
            _kernel.Bind<IBuildingRepository>().To<BuildingRepository>();
            _kernel.Bind<IUnitRepository>().To<UnitRepository>();
        }
    }
}