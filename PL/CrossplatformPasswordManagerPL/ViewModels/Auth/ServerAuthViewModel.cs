using Autofac;
using Autofac.Core;
using Avalonia.DesignerSupport;
using Avalonia.Threading;
using AvaloniaInside.Shell;
using CrossplatformPasswordManagerPL.Helpers;
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
    private bool _isErrorMessageUrl;
    private string _url;
    private bool _isErrorMessageLogin;
    private string _login;
    private bool _isErrorMessagePassword;
    private string _password;
    private bool _isProsessAuth;


    public ICommand AuthCommand { get; set; }
    public ObservableCollection<string> TypeURL { get; set; } = new ObservableCollection<string>()
    {
        "https", "http"
    };
    public string TypeURLSelectedItem { get; set; }
    public bool IsErrorMessageURL
    {
        get => _isErrorMessageUrl;
        set => this.RaiseAndSetIfChanged(ref _isErrorMessageUrl, value);
    }

    public string URL
    {
        get => _url;
        set
        {
            this.RaiseAndSetIfChanged(ref _url, value);
            IsErrorMessageURL = ValidateText(_url);
        }
    }
    public bool IsErrorMessageLogin
    {
        get => _isErrorMessageLogin;
        set => this.RaiseAndSetIfChanged(ref _isErrorMessageLogin, value);
    }
    public string Login
    {
        get => _login;
        set
        {
            this.RaiseAndSetIfChanged(ref _login, value);
            IsErrorMessageLogin = ValidateText(_login);
        }
    }
    public bool IsErrorMessagePassword
    {
        get => _isErrorMessagePassword;
        set => this.RaiseAndSetIfChanged(ref _isErrorMessagePassword, value);
    }
    public string Password
    {
        get => _password;
        set
        {
            this.RaiseAndSetIfChanged(ref _password, value);
            IsErrorMessagePassword = ValidateText(_password);
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
        IsErrorMessageURL = IsErrorMessageLogin = IsErrorMessagePassword = false;
        IsProcessAuth = false;

        _navigationService = navigationService;
        AuthCommand = ReactiveCommand.CreateFromTask(TryServerAuth);
    }

    private async Task TryServerAuth()
    {
        IsProcessAuth = true;
        IsErrorMessageURL = ValidateText(URL);
        IsErrorMessageURL = ValidateText(Login);
        IsErrorMessageURL = ValidateText(Password);
        if (IsErrorMessageURL || IsErrorMessageLogin || IsErrorMessagePassword)
        {
            IsProcessAuth = false;
            return;
        }
        using (var scope = ServiceModule.Container?.BeginLifetimeScope())
        {
            var authLogic = scope?.Resolve<IAuthLogic>();
            if (authLogic != null)
            {
                var statusAuth = await authLogic.CheckServerAuth(URL, Login, Password);
                if (statusAuth)
                {
                    await PageLocator.StepToLocalAuthPage(_navigationService);
                    return;
                }
            }
        }
        IsProcessAuth = false; 
    }

    public bool ValidateText(string Text)
    {
        if (string.IsNullOrEmpty(Text))
        {
            return true;
        }
        return false;
    }
}

// TODO
// добавить ресурсы для PL (весь текст в ресурсы)
// добавить локализации (пока только Ru - default)
// доделать сохранение токена в LocalStorage
// начать делать LocalAuth