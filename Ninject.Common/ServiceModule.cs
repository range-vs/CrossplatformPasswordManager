using Autofac.Core;
using Autofac;
using Database.Contracts.DAL;
using Database.Core.DAL;
using Database.Contracts.BLL;
using Database.Core.BLL;
using System.Diagnostics;
using Server.Core.BLL;
using Server.Contracts.BLL;
using Sequrity.Contracts.BLL;
using Sequrity.Core.BLL;
using LocalStorage.Core.DAL;
using LocalStorage.Contratcs.DAL;

namespace Ninject.Common
{
    public static class ServiceModule
    {
        public static IContainer? Container { get; set; } = null;

        public static bool Init()
        {
            try
            {
                var builder = new ContainerBuilder();
                // DAL
                builder.RegisterType<GroupDbDao>().As<IGroupDbDao>();
                builder.RegisterType<LocalStorageDao>().As<ILocalStorageDao>();

                // BLL
                builder.RegisterType<GroupLogic>().As<IGroupLogic>();
                builder.RegisterType<AuthLogic>().As<IAuthLogic>();
                builder.RegisterType<AuthSequrityLogic>().As<IAuthSequrityLogic>();

                // Platform Specific
                if (OperatingSystem.IsWindows())
                {

                }
                else if (OperatingSystem.IsLinux())
                {

                }
                else if (OperatingSystem.IsAndroid())
                {

                }
                else if (OperatingSystem.IsIOS())
                {

                }
                else if(OperatingSystem.IsBrowser())
                {

                }
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
