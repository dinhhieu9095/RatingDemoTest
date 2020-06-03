
using Autofac;
using Autofac.Integration.Mvc;
using RatingDemoTest.Business.Interface;
using RatingDemoTest.Repository.EF;
using RatingDemoTest.Repository.Interface;
using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(RatingDemoTest.MVC.Autofac), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(RatingDemoTest.MVC.Autofac), "Stop")]
namespace RatingDemoTest.MVC
{
    public static class Autofac
    {
        #region Variables and Properties

        private static readonly ContainerBuilder container = new ContainerBuilder();
        private static IContainer containerBase;

        #endregion

        #region Public Methods
        public static void Start()
        {
            container.RegisterControllers(Assembly.GetExecutingAssembly());
            container.RegisterFilterProvider();
            RegisterService(container);
            containerBase = container.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(containerBase));
        }
        public static void Stop()
        {
            containerBase.Dispose();
        }
        #endregion

        #region Private Methods
        private static void RegisterService(ContainerBuilder container)
        {
            RegisterService_Business(container);
            RegisterService_Database(container);
        }
        private static void RegisterService_Business(ContainerBuilder container)
        {
            container.RegisterType<RatingDemoTest.Business.Concrete.Business>().As<IBusiness>().InstancePerRequest();
        }
        private static void RegisterService_Database(ContainerBuilder container)
        {
            container.RegisterType<DbContext>().As<DbContext>().WithParameter("nameOrConnectionString", "name=RatingDemoTestEntities");
            container.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
        }
        #endregion
    }
}