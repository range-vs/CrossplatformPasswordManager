using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CrossplatformPasswordManagerPL.Views.PlatformSpecific.Windows;
using CrossplatformPasswordManagerPL.ViewModels;
using CrossplatformPasswordManagerPL.Views;
using System.Globalization;

using Ninject.Common;
using System.Threading;
using PlatformSpecific.Contracts.PSL.Files;
using System.Collections.Generic;
using System;
using Helpers.Common.Internet;

namespace CrossplatformPasswordManagerPL;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        ServiceModule.InitForPlatform(
                        new KeyValuePair<Type, Type>(typeof(ServerSaver), typeof(IServerSaver))
            );
    }

    public override void OnFrameworkInitializationCompleted()
    {
        //CultureInfo.CurrentUICulture = new CultureInfo("en-US", false);
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new Window
            {
                DataContext = new CommonViewModel()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new CommonView
            {
                DataContext = new CommonViewModel()
            };
        }
        base.OnFrameworkInitializationCompleted();
    }
}
