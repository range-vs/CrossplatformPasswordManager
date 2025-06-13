using Autofac;
using AvaloniaInside.Shell;
using CrossplatformPasswordManagerPL.Assets;
using CrossplatformPasswordManagerPL.Helpers;
using Ninject.Common;
using PlatformSpecific.Contracts.PSL.Sequrity;
using ReactiveUI;
using Server.Contracts.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CrossplatformPasswordManagerPL.ViewModels.Auth
{
    public class OSAuthViewModel : ViewModelBase
    {
        private readonly INavigator _navigationService;
        private string _processAuth;
        private bool _isFailedProcessAuth;
        public ICommand RepeatAuthCommand { get; set; }

        public string ProcessAuth
        {
            get => _processAuth;
            set
            {
                this.RaiseAndSetIfChanged(ref _processAuth, value);
            }
        }
        public bool IsFailedProcessAuth
        {
            get => _isFailedProcessAuth;
            set
            {
                this.RaiseAndSetIfChanged(ref _isFailedProcessAuth, value);
            }
        }

        public OSAuthViewModel(INavigator navigationService)
        {
            _navigationService = navigationService;
            IsFailedProcessAuth = false;
            _ = Auth();
            RepeatAuthCommand = ReactiveCommand.CreateFromTask(Auth);
        }


        private async Task Auth()
        {
            ProcessAuth = Resources.OSAuthProcessText;
            using (var scope = ServiceModule.Container?.BeginLifetimeScope())
            {
                var osAuthLogic = scope?.Resolve<IOSAuthPlatformSpecific>();
                if (osAuthLogic != null)
                {
                    var statusAuth = await osAuthLogic.RequestAuth();
                    if (statusAuth)
                    {
                        IsFailedProcessAuth = false;
                        ProcessAuth = "Auth valid!";
                        await PageLocator.StepToListGroupsRecordsPage(_navigationService);
                    }
                    else
                    {
                        IsFailedProcessAuth = true;
                        ProcessAuth = Resources.OSAuthErrorText;
                    }
                }
            }
        }
    }
}