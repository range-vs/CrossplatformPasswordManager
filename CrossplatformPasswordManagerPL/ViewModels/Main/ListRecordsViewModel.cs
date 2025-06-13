using Autofac;
using Avalonia.Controls;
using AvaloniaInside.Shell;
using CrossplatformPasswordManagerPL.Assets;
using CrossplatformPasswordManagerPL.Helpers;
using CrossplatformPasswordManagerPL.Helpers.UI;
using Database.Contracts.BLL;
using DialogHostAvalonia;
using DynamicData.Binding;
using Helpers.Common.Internet;
using Helpers.Common.Mapper;
using Models.Common;
using Ninject.Common;
using PlatformSpecific.Contracts.PSL.Sequrity;
using ReactiveUI;
using Server.Contracts.BLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CrossplatformPasswordManagerPL.ViewModels.Main
{
    public class ListRecordsViewModel : ViewModelBase
    {
        private readonly INavigator _navigationService;
        private readonly IResourceDictionary _resources;

        private ObservableCollection<GroupModel> _records;
        private GroupModel _currentRecord;
        private bool _isLoadData;

        public ICommand AddCommand { get; set; }

        public ICommand RenameCommand { get; set; }
        public ICommand RemoveCommand { get; set; }

        public ICommand RenameApplyCommand { get; set; }
        public ICommand RemoveApplyCommand { get; set; }
        public ICommand RemoveAndRenameCancelCommand { get; set; }

        public ObservableCollection<GroupModel> Records
        {
            get => _records;
            set => this.RaiseAndSetIfChanged(ref _records, value);
        }
        public GroupModel CurrentRecord
        {
            get => _currentRecord;
            set => this.RaiseAndSetIfChanged(ref _currentRecord, value);
        }
        public bool IsLoadData
        {
            get => _isLoadData;
            set => this.RaiseAndSetIfChanged(ref _isLoadData, value);
        }

        public ListRecordsViewModel(INavigator navigationService, IResourceDictionary resources)
        {
            _navigationService = navigationService;
            _resources = resources;
            IsLoadData = true;
            AddCommand = ReactiveCommand.Create(Add);
            RenameCommand = ReactiveCommand.CreateFromTask(Rename);
            RemoveCommand = ReactiveCommand.CreateFromTask(Remove);
            RenameApplyCommand = ReactiveCommand.CreateFromTask(RenameApply);
            RemoveApplyCommand = ReactiveCommand.CreateFromTask(RemoveApply);
            RemoveAndRenameCancelCommand = ReactiveCommand.Create(RemoveAndRenameCancel);
            _ = Init();
        }

        private async Task Init()
        {
            using (var scope = ServiceModule.Container?.BeginLifetimeScope())
            {
                var mapper = scope?.Resolve<ICPMapper>();
                if (mapper != null)
                {
                    var groupsLogic = scope?.Resolve<IGroupDbLogic>();
                    if (groupsLogic != null)
                    {
                        var rec = await groupsLogic.GetAll();
                        Records = mapper.GetMapper().Map<ObservableCollection<GroupModel>>(rec);
                    }
                }
            }
            IsLoadData = false;
            using (var scope = ServiceModule.Container?.BeginLifetimeScope())
            {
                var servertask = scope?.Resolve<IServerSaver>();
                if (servertask != null)
                {
                    await servertask.Run();
                }
            }
        }

        private async Task Add()
        {
            using (var scope = ServiceModule.Container?.BeginLifetimeScope())
            {
                var toasts = scope?.Resolve<IToastControlContainer>();
                toasts?.Show(TimeSpan.FromSeconds(3), "Подключение к интернету потеряно");
            }
        }

        private async Task Remove()
        {
            await DialogHost.Show(_resources[Resources.RemoveRecordDialogId]!, Resources.ListRecordsDialogId);
        }

        private async Task Rename()
        {
            await DialogHost.Show(_resources[Resources.RenameRecordDialogId]!, Resources.ListRecordsDialogId);
        }

        private async Task RenameApply()
        {
            // TODO ренейм записи из БД(+ на сервере) и обновление ui
            return;
        }

        private async Task RemoveApply()
        {
            // TODO удаление записи из БД(+ на сервере) и обновление ui
            return;
        }

        private void RemoveAndRenameCancel()
        {
            DialogHost.GetDialogSession(Resources.ListRecordsDialogId)?.Close(false);
        }
    }
}