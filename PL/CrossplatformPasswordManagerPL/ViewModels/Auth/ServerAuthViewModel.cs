using Autofac;
using Autofac.Core;
using Avalonia.DesignerSupport;
using Avalonia.Threading;
using AvaloniaInside.Shell;
using Database.Contracts.BLL;
using DynamicData.Binding;
using Entities.Common;
using Models.Common;
using Ninject.Common;
using ReactiveUI;
using Server.Contracts.BLL;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CrossplatformPasswordManagerPL.ViewModels.Auth;

public class ServerAuthViewModel : ViewModelBase
{
    private readonly INavigator _navigationService;

    public ICommand Click { get; }

    public ServerAuthViewModel(INavigator navigationService)
    {
        _navigationService = navigationService;
        Click = ReactiveCommand.Create(() =>
        {
            // Debug.WriteLine(Greeting);
        });

    }
}
