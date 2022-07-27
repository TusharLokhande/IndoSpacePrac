using IndoSpacePrac.Data.Repository;
using IndoSpacePrac.Service.Employee;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Unity.Injection;

namespace IndoSpacePrac.FrameWork
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            


            container.RegisterType(typeof(IRepository<>), typeof(BaseRepository<>));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            //container.RegisterType<IRepository<T>, BaseRepository<T>>();
            //container.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            // container.RegisterType(), CustomerRepository>();

        }
    }
}