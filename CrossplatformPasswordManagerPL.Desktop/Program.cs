using System;
using System.Collections.Generic;
using Autofac.Core;
using Avalonia;
using Avalonia.ReactiveUI;
using AvaloniaInside.Shell;
using CrossplatformPasswordManagerPL.Desktop.Files;
using Ninject.Common;
using PlatformSpecific.Contracts.PSL;

namespace CrossplatformPasswordManagerPL.Desktop;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
    {
        var types = new Dictionary<Type, Type>
        {
            { typeof(FilesProvider), typeof(IFilesProviderPlatformSpecific) }
        };
        ServiceModule.InitForPlatform(types);
        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .UseShell()
            .LogToTrace()
            .UseReactiveUI();
    }
}
