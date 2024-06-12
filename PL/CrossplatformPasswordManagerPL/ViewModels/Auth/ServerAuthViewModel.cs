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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CrossplatformPasswordManagerPL.ViewModels.Auth;

public class ServerAuthViewModel : ViewModelBase
{
    private readonly INavigator _navigationService;
    private string _errorMessageUrl;
    private string _url;
    private string _errorMessageLogin;
    private string _login;
    private string _errorMessagePassword;
    private string _password;
    private bool _isProsessAuth;


    public ICommand AuthCommand { get; set; }
    public ObservableCollection<string> TypeURL { get; set; } = new ObservableCollection<string>()
    {
        "https", "http"
    };
    public string TypeURLSelectedItem { get; set; }
    public string ErrorMessageURL
    {
        get => _errorMessageUrl;
        set => this.RaiseAndSetIfChanged(ref _errorMessageUrl, value);
    }

    public string URL
    {
        get => _url;
        set
        {
            this.RaiseAndSetIfChanged(ref _url, value);
            ErrorMessageURL = ValidateText(_url);
        }
    }
    public string ErrorMessageLogin
    {
        get => _errorMessageLogin;
        set => this.RaiseAndSetIfChanged(ref _errorMessageLogin, value);
    }
    public string Login
    {
        get => _login;
        set
        {
            this.RaiseAndSetIfChanged(ref _login, value);
            ErrorMessageLogin = ValidateText(_login);
        }
    }
    public string ErrorMessagePassword
    {
        get => _errorMessagePassword;
        set => this.RaiseAndSetIfChanged(ref _errorMessagePassword, value);
    }
    public string Password
    {
        get => _password;
        set
        {
            this.RaiseAndSetIfChanged(ref _password, value);
            ErrorMessagePassword = ValidateText(_password);
        }
    }
    public bool IsProcessAuth
    {
        get => _isProsessAuth;
        set => this.RaiseAndSetIfChanged(ref _isProsessAuth, value);
    }

    public ServerAuthViewModel(INavigator navigationService)
    {
        TypeURLSelectedItem = TypeURL[0];
        ErrorMessageURL = ErrorMessageLogin = ErrorMessagePassword = string.Empty;
        IsProcessAuth = false;

        _navigationService = navigationService;
        AuthCommand = ReactiveCommand.CreateFromTask(TryServerAuth);
    }

    private async Task TryServerAuth()
    {
        IsProcessAuth = true;
        ErrorMessageURL = ValidateText(URL);
        ErrorMessageLogin = ValidateText(Login);
        ErrorMessagePassword = ValidateText(Password);
        if (ErrorMessageURL != string.Empty || ErrorMessageLogin != string.Empty || ErrorMessagePassword != string.Empty)
        {
            IsProcessAuth = false;
            return;
        }
        using (var scope = ServiceModule.Container?.BeginLifetimeScope())
        {
            var authLogic = scope?.Resolve<IAuthLogic>();
            var statusAuth = await authLogic?.CheckServerAuth(URL, Login, Password);
            if(statusAuth)
            {
                await _navigationService.NavigateAsync("/local_auth");
                return;
            }
        }
        IsProcessAuth = false; 
    }

    public string ValidateText(string Text)
    {
        if (string.IsNullOrEmpty(Text))
        {
            return "Значение не может быть пустым";
        }
        return string.Empty;
    }
}
