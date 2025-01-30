using Android.App;
using Android.Content.PM;
using Avalonia;
using Avalonia.Android;
using Avalonia.ReactiveUI;
using AvaloniaInside.Shell;
using CrossplatformPasswordManagerPL.Android.Files;
using Ninject.Common;
using PlatformSpecific.Contracts.PSL;
using System;
using System.Collections.Generic;

namespace CrossplatformPasswordManagerPL.Android;

[Activity(
    Label = "CrossplatformPasswordManagerPL.Android",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
public class MainActivity : AvaloniaMainActivity<App>
{
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        ServiceModule.InitForPlatform(
            new KeyValuePair<Type, Type>(typeof(FilesProvider), typeof(IFilesProviderPlatformSpecific))
        );
        return base.CustomizeAppBuilder(builder)
            .WithInterFont()
            .UseShell()
            .UseReactiveUI();
    }
}
