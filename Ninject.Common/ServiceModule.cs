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
using Helpers.Common.Mapper;
using Helpers.Common.Internet;

namespace Ninject.Common
{
    public static class ServiceModule
    {
        private static ContainerBuilder _builder = new ContainerBuilder();
        public static IContainer? Container { get; set; } = null;

        public static bool InitForPlatform(params KeyValuePair<object, Type>[] platformTypes)
        {
            try
            {
                foreach (var type in platformTypes)
                {
                    _builder.RegisterInstance(type.Key).As(type.Value);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }

            return true;
        }

        public static bool InitForPlatform(params KeyValuePair<Type, Type> [] platformTypes)
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
                _builder.RegisterType<GroupServerDao>().As<IGroupServerDao>();
                _builder.RegisterType<LocalStorageDao>().As<ILocalStorageDao>();

                // BLL
                _builder.RegisterType<GroupDbLogic>().As<IGroupDbLogic>();
                _builder.RegisterType<GroupServerLogic>().As<IGroupServerLogic>();
                _builder.RegisterType<AuthLogic>().As<IAuthLogic>();
                _builder.RegisterType<AuthSequrityLogic>().As<IAuthSequrityLogic>();

                // Mapper
                _builder.RegisterInstance(new CPMapper()).As<ICPMapper>();

                // Internet task
                _builder.RegisterType<ServerSaver>().As<IServerSaver>();

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
