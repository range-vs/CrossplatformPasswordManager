using Autofac;
using AvaloniaInside.Shell;
using CrossplatformPasswordManagerPL.Assets;
using CrossplatformPasswordManagerPL.Helpers;
using Ninject.Common;
using PlatformSpecific.Contracts.PSL.Sequrity;
using ReactiveUI;
using Server.Contracts.BLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CrossplatformPasswordManagerPL.ViewModels.Main
{
    public class ListRecordsViewModel : ViewModelBase
    {
        private readonly INavigator _navigationService;
        private ObservableCollection<string> _records;
        public ICommand RepeatAuthCommand { get; set; }

        public ObservableCollection<string> Records
        {
            get => _records;
            set => this.RaiseAndSetIfChanged(ref _records, value);
        }
        public ListRecordsViewModel(INavigator navigationService)
        {
            _navigationService = navigationService;
            RepeatAuthCommand = ReactiveCommand.CreateFromTask(Auth);
            // TODO: загрузить данные через DШ(синглтон, запомнить данные в DI)
            Records = new ObservableCollection<string>() { "Ivan", "run club", "mother"};
        }


        private async Task Auth()
        {
            using (var scope = ServiceModule.Container?.BeginLifetimeScope())
            {
                var osAuthLogic = scope?.Resolve<IOSAuthPlatformSpecific>();
                if (osAuthLogic != null)
                {
                    var statusAuth = await osAuthLogic.RequestAuth();
                    
                }
            }
        }
    }
}