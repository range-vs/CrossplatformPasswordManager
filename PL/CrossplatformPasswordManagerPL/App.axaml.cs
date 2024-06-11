using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CrossplatformPasswordManagerPL.Views.PlatformSpecific.Windows;
using CrossplatformPasswordManagerPL.ViewModels;
using CrossplatformPasswordManagerPL.Views;

using Ninject.Common;

namespace CrossplatformPasswordManagerPL;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        ServiceModule.Init();
    }

    public override void OnFrameworkInitializationCompleted()
    {
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
