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
using PlatformSpecific.Contracts.PSL;
using System.Collections;

namespace Ninject.Common
{
    public static class ServiceModule
    {
        private static ContainerBuilder _builder = new ContainerBuilder();
        public static IContainer? Container { get; set; } = null;

        public static bool InitForPlatform(Dictionary<Type, Type> platformTypes)
        {
            try
            {
                foreach (var type in platformTypes)
                {
                    _builder.RegisterType(type.Key).As(type.Value);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
            return true;
        }

        public static bool Init()
        {
            try
            {
                // DAL
                _builder.RegisterType<GroupDbDao>().As<IGroupDbDao>();
                _builder.RegisterType<LocalStorageDao>().As<ILocalStorageDao>();

                // BLL
                _builder.RegisterType<GroupLogic>().As<IGroupLogic>();
                _builder.RegisterType<AuthLogic>().As<IAuthLogic>();
                _builder.RegisterType<AuthSequrityLogic>().As<IAuthSequrityLogic>();

                //// Platform Specific
                //if (OperatingSystem.IsWindows())
                //{
                //    //_builder.RegisterType<PlatformSpecific.Windows.PSL.FilesProviderPlatformSpecific>().As<IFilesProviderPlatformSpecific>();
                //}
                //else if (OperatingSystem.IsLinux())
                //{
                //    _builder.RegisterType<PlatformSpecific.Linux.PSL.FilesProviderPlatformSpecific>().As<IFilesProviderPlatformSpecific>();
                //}
                //else if (OperatingSystem.IsAndroid())
                //{
                //    //_builder.RegisterType<PlatformSpecific.Android.PSL.FilesProviderPlatformSpecific>().As<IFilesProviderPlatformSpecific>();
                //}
                //else if(OperatingSystem.IsBrowser())
                //{
                //    _builder.RegisterType<PlatformSpecific.Browser.PSL.FilesProviderPlatformSpecific>().As<IFilesProviderPlatformSpecific>();
                //}

                // ctor DI
                Container = _builder.Build();
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
