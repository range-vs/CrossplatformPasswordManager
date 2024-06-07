using Autofac.Core;
using Autofac;
using Database.Contracts.DAL;
using Database.Core.DAL;
using Database.Contracts.BLL;
using Database.Core.BLL;
using System.Diagnostics;

namespace Ninject.Common
{
    public static class ServiceModule // TODO: сделать юнит тест на прогонку всех DI
    {
        public static IContainer? Container { get; set; } = null;

        public static bool Init()
        {
            try
            {
                var builder = new ContainerBuilder();
                // DAL
                builder.RegisterType<GroupDbDao>().As<IGroupDbDao>();

                // BLL
                builder.RegisterType<GroupLogic>().As<IGroupLogic>();

                // ctor DI
                Container = builder.Build();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
            return true;
        }

        // using in PL etc:
        //using (var scope = _container.BeginLifetimeScope())
        //{
        //    var myService = scope.Resolve<IMyService>();
        //    myService.DoSomething();
        //}

    }
}
