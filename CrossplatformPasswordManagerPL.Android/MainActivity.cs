using Android.App;
using Android.Content.PM;
using Avalonia;
using Avalonia.Android;
using Avalonia.ReactiveUI;
using AvaloniaInside.Shell;
using CrossplatformPasswordManagerPL.Android.DI;
using CrossplatformPasswordManagerPL.Android.Files;
using CrossplatformPasswordManagerPL.Android.Internet;
using CrossplatformPasswordManagerPL.Android.Sequrity;
using Ninject.Common;
using PlatformSpecific.Contracts.PSL.Files;
using PlatformSpecific.Contracts.PSL.Internet;
using PlatformSpecific.Contracts.PSL.Sequrity;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CrossplatformPasswordManagerPL.Android
{
    [Activity(
        Label = "CrossplatformPasswordManagerPL.Android",
        Theme = "@style/MyTheme.NoActionBar",
        Icon = "@drawable/icon",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
    public class MainActivity : AvaloniaMainActivity<App>
    {
        public MainActivityProvider MainActivityProvider { get; set; }

        protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
        {
            MainActivityProvider = new MainActivityProvider(this);
            ServiceModule.InitForPlatform(
                new KeyValuePair<Type, Type>(typeof(FilesProvider), typeof(IFilesProviderPlatformSpecific)),
                new KeyValuePair<Type, Type>(typeof(OSAuth), typeof(IOSAuthPlatformSpecific)),
                new KeyValuePair<Type, Type>(typeof(InternetAdapterChecker), typeof(IInternetAdapterChecker))
            );
            ServiceModule.InitForPlatform(
                new KeyValuePair<object, Type>(MainActivityProvider, typeof(IMainActivityProvider))
            );
            return base.CustomizeAppBuilder(builder)
                .WithInterFont()
                .UseShell()
                .UseReactiveUI();
        }

        public override void OnBackPressed()
        {
            // TODO: в будущем предлагать закрыть аппу
            MoveTaskToBack(true);
        }
    }

}
