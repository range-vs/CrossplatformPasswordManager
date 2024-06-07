using Autofac;
using Autofac.Core;
using Avalonia.DesignerSupport;
using Avalonia.Threading;
using Database.Contracts.BLL;
using DynamicData.Binding;
using Entities.Common;
using Models.Common;
using Ninject.Common;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CrossplatformPasswordManager.ViewModels;

public class MainViewModel : ViewModelBase
{

    public Task<string> Greeting => GetTextAsync();
    public Task<string> ButtonName => GetTextAsync1();
    public Task<ObservableCollection<GroupModel>> Groups => GetGroups();


    private async Task<string> GetTextAsync()
    {
        using (var scope = ServiceModule.Container?.BeginLifetimeScope())
        {
            var groupLogicService = scope?.Resolve<IGroupLogic>();
            var collection = await groupLogicService?.GetAll();
            var list = new List<GroupModel>(collection);
            return list[0].Name;
            //Debug.WriteLine(collection.Result);
        }
    }

    private async Task<string> GetTextAsync1()
    {
        using (var scope = ServiceModule.Container?.BeginLifetimeScope())
        {
            var groupLogicService = scope?.Resolve<IGroupLogic>();
            var collection = await groupLogicService?.GetAll();
            var list = new List<GroupModel>(collection);
            return list[1].Name;
            //Debug.WriteLine(collection.Result);
        }
    }

    private async Task<ObservableCollection<GroupModel>> GetGroups()
    {
        using (var scope = ServiceModule.Container?.BeginLifetimeScope())
        {
            var groupLogicService = scope?.Resolve<IGroupLogic>();
            var collection = await groupLogicService?.GetAll();
            return new ObservableCollection<GroupModel>(collection);
            //Debug.WriteLine(collection.Result);
        }
    }

    public ICommand Click { get; }

    public MainViewModel() 
    {
        Click = ReactiveCommand.Create(() =>
        {
            // Debug.WriteLine(Greeting);
        });

    }
}
