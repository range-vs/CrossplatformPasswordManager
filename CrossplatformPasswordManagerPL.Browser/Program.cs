﻿using System;
using System.Collections.Generic;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Browser;
using Avalonia.ReactiveUI;
using AvaloniaInside.Shell;
using CrossplatformPasswordManagerPL;
using CrossplatformPasswordManagerPL.Browser.Files;
using Ninject.Common;
using PlatformSpecific.Contracts.PSL;

[assembly: SupportedOSPlatform("browser")]

internal sealed partial class Program
{
    private static Task Main(string[] args) => BuildAvaloniaApp()
            .WithInterFont()
            .UseReactiveUI()
            .UseShell()
            .StartBrowserAppAsync("out");

    public static AppBuilder BuildAvaloniaApp()
    {
        ServiceModule.InitForPlatform(
            new KeyValuePair<Type, Type>(typeof(FilesProvider), typeof(IFilesProviderPlatformSpecific))
        );
        return AppBuilder.Configure<App>();
    }
}