using IndoSpacePrac.Data.Repository;
using IndoSpacePrac.Service.Employee;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Unity.Injection;
using IndoSpacePrac.Service.DropDown;

namespace IndoSpacePrac.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType(typeof(IRepository<>), typeof(BaseRepository<>));
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IDropDown, DropDownService>();

        }
    }
}