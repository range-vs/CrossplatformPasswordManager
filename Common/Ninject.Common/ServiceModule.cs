using Autofac.Core;
using Autofac;
using Database.Contracts.NAL;
using Database.Core.NAL;
using Database.Contracts.DAL;
using Database.Core.DAL;
using Database.Contracts.BLL;
using Database.Core.BLL;

namespace Ninject.Common
{
    public class ServiceModule
    {
        public static IContainer Container { get; set; }

        static ServiceModule()
        {
            var builder = new ContainerBuilder();
            // NAL
            builder.RegisterType<IGroupNetDao>().As<GroupNetDao>();

            // DAL
            builder.RegisterType<IGroupDbDao>().As<GroupDbDao>();

            // BLL
            builder.RegisterType<IGroupLogic>().As<GroupLogic>();

            // ctor DI
            Container = builder.Build();
        }

        // using in PL etc:
        //using (var scope = _container.BeginLifetimeScope())
        //{
        //    var myService = scope.Resolve<IMyService>();
        //    myService.DoSomething();
        //}

    }
}
