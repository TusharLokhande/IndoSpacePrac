using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using  IndoSpacePrac.Core.Infrastructure;
using IndoSpacePrac.Service.Employee;
using Autofac.Core;
using Autofac.Builder;
using IndoSpacePrac.Data.Repository;
using IndoSpacePrac.Core.Configuration;
using System.Reflection;
using IndoSpacePrac.Service.Security.Configuration;

namespace IndoSpacePrac.FrameWork
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {

            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());

            //controllers
            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());

            

            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            
            //Employee service
            builder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerLifetimeScope();
        }



        public int Order
        {
            get { return 0; }
        }


        public class SettingsSource : IRegistrationSource
        {
            static readonly MethodInfo BuildMethod = typeof(SettingsSource).GetMethod(
                "BuildRegistration",
                BindingFlags.Static | BindingFlags.NonPublic);

            public IEnumerable<IComponentRegistration> RegistrationsFor(
                    Autofac.Core.Service service,
                    Func<Autofac.Core.Service, IEnumerable<IComponentRegistration>> registrations)
            {
                var ts = service as TypedService;
                if (ts != null && typeof(ISettings).IsAssignableFrom(ts.ServiceType))
                {
                    var buildMethod = BuildMethod.MakeGenericMethod(ts.ServiceType);
                    yield return (IComponentRegistration)buildMethod.Invoke(null, null);
                }
            }

            static IComponentRegistration BuildRegistration<TSettings>() where TSettings : ISettings, new()
            {
                return RegistrationBuilder
                    .ForDelegate((c, p) =>
                    {
                        var currentStoreId = 0;//c.Resolve<IStoreContext>().CurrentStore.Id;
                                               //uncomment the code below if you want load settings per store only when you have two stores installed.
                                               //var currentStoreId = c.Resolve<IStoreService>().GetAllStores().Count > 1
                                               //    c.Resolve<IStoreContext>().CurrentStore.Id : 0;

                        //although it's better to connect to your database and execute the following SQL:
                        //DELETE FROM [Setting] WHERE [StoreId] > 0
                        return c.Resolve<ISettingService>().LoadSetting<TSettings>(currentStoreId);
                    })
                    .InstancePerLifetimeScope()
                    .CreateRegistration();
            }

            //public IEnumerable<IComponentRegistration> RegistrationsFor(Autofac.Core.Service service, Func<Autofac.Core.Service, IEnumerable<IComponentRegistration>> registrationAccessor)
            //{
            //    var ts = service as TypedService;
            //    if (ts != null && typeof(ISettings).IsAssignableFrom(ts.ServiceType))
            //    {
            //        var buildMethod = BuildMethod.MakeGenericMethod(ts.ServiceType);
            //        yield return (IComponentRegistration)buildMethod.Invoke(null, null);
            //    }

            //}

            public bool IsAdapterForIndividualComponents { get { return false; } }
        }
    }
}
