using Autofac;
using Autofac.Core;
using Avalonia.Animation;
using Avalonia.DesignerSupport;
using Avalonia.Threading;
using AvaloniaInside.Shell;
using AvaloniaInside.Shell.Platform;
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

namespace CrossplatformPasswordManagerPL.ViewModels;

public class CommonViewModel : ViewModelBase
{

    //public Task<string> Greeting => GetTextAsync();
    //public Task<string> ButtonName => GetTextAsync1();
    //public Task<ObservableCollection<GroupModel>> Groups => GetGroups();


    //private async Task<string> GetTextAsync()
    //{
    //    using (var scope = ServiceModule.Container?.BeginLifetimeScope())
    //    {
    //        var groupLogicService = scope?.Resolve<IGroupLogic>();
    //        var collection = await groupLogicService?.GetAll();
    //        var list = new List<GroupModel>(collection);
    //        return list[0].Name;
    //        //Debug.WriteLine(collection.Result);
    //    }
    //}

    //private async Task<string> GetTextAsync1()
    //{
    //    using (var scope = ServiceModule.Container?.BeginLifetimeScope())
    //    {
    //        var groupLogicService = scope?.Resolve<IGroupLogic>();
    //        var collection = await groupLogicService?.GetAll();
    //        var list = new List<GroupModel>(collection);
    //        return list[1].Name;
    //        //Debug.WriteLine(collection.Result);
    //    }
    //}

    //private async Task<ObservableCollection<GroupModel>> GetGroups()
    //{
    //    using (var scope = ServiceModule.Container?.BeginLifetimeScope())
    //    {
    //        var groupLogicService = scope?.Resolve<IGroupLogic>();
    //        var collection = await groupLogicService?.GetAll();
    //        return new ObservableCollection<GroupModel>(collection);
    //        //Debug.WriteLine(collection.Result);
    //    }
    //}

    //public ICommand Click { get; }


    private IPageTransition _currentTransition = PlatformSetup.TransitionForPage;
    public IPageTransition CurrentTransition
    {
        get => _currentTransition;
        set
        {
            this.RaiseAndSetIfChanged(ref _currentTransition, value);
        }
    }

    public string StartPage { get; set; }

    public CommonViewModel()
    {
        StartPage = "/server_auth";
        //Click = ReactiveCommand.Create(() =>
        //{
        //    // Debug.WriteLine(Greeting);
        //});

        //using (var scope = ServiceModule.Container?.BeginLifetimeScope())
        //{
        //    var authLogic = scope?.Resolve<IAuthLogic>();
        //    authLogic?.TryServerAuth("url", "login", "password");
        //}
    }

}
