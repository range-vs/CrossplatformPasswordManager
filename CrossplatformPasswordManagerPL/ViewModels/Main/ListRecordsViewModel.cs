using Autofac;
using Avalonia.Controls;
using AvaloniaInside.Shell;
using CrossplatformPasswordManagerPL.Assets;
using CrossplatformPasswordManagerPL.Helpers;
using DialogHostAvalonia;
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

        private ObservableCollection<string> _records;
        private string _currentRecord;

        public ICommand RenameCommand { get; set; }
        public ICommand RemoveCommand { get; set; }

        public ICommand RenameApplyCommand { get; set; }
        public ICommand RemoveApplyCommand { get; set; }
        public ICommand RemoveAndRenameCancelCommand { get; set; }

        public ObservableCollection<string> Records
        {
            get => _records;
            set => this.RaiseAndSetIfChanged(ref _records, value);
        }
        public string CurrentRecord
        {
            get => _currentRecord;
            set => this.RaiseAndSetIfChanged(ref _currentRecord, value);
        }

        public ListRecordsViewModel(INavigator navigationService, IResourceDictionary resources)
        {
            _navigationService = navigationService;
            _resources = resources;
            RenameCommand = ReactiveCommand.CreateFromTask(Rename);
            RemoveCommand = ReactiveCommand.CreateFromTask(Remove);
            RenameApplyCommand = ReactiveCommand.CreateFromTask(RenameApply);
            RemoveApplyCommand = ReactiveCommand.CreateFromTask(RemoveApply);
            RemoveAndRenameCancelCommand = ReactiveCommand.Create(RemoveAndRenameCancel);
            // сделать набор сущностей и загрузить их с сервера (пока имитация)
            // TODO: загрузить данные через DШ(синглтон, запомнить данные в DI)
            // настроить кастомную ui
            // настроить биндинг строчки из list view
            Records = new ObservableCollection<string>() { "Ivan", "run club", "mother"};
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