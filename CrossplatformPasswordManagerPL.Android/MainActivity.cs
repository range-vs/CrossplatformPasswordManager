using Android.App;
using Android.Content.PM;
using Avalonia;
using Avalonia.Android;
using Avalonia.ReactiveUI;
using AvaloniaInside.Shell;
using CrossplatformPasswordManagerPL.Android.Files;
using CrossplatformPasswordManagerPL.Android.Sequrity;
using Ninject.Common;
using PlatformSpecific.Contracts.PSL;
using PlatformSpecific.Contracts.PSL.Sequrity;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CrossplatformPasswordManagerPL.Android;

[Activity(
    Label = "CrossplatformPasswordManagerPL.Android",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
public class MainActivity : AvaloniaMainActivity<App>
{
    public static MainActivity activity = null;
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        activity = this;
        ServiceModule.InitForPlatform(
            new KeyValuePair<Type, Type>(typeof(FilesProvider), typeof(IFilesProviderPlatformSpecific)),
            new KeyValuePair<Type, Type>(typeof(OSAuth), typeof(IOSAuthPlatformSpecific))
        );
        return base.CustomizeAppBuilder(builder)
            .WithInterFont()
            .UseShell()
            .UseReactiveUI();
    }
}
