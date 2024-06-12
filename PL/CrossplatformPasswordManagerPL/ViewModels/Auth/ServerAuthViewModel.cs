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

    public ServerAuthViewModel(INavigator navigationService)
    {
        TypeURLSelectedItem = TypeURL[0];
        ErrorMessageURL = ErrorMessageLogin = ErrorMessagePassword = string.Empty;

        _navigationService = navigationService;
        AuthCommand = ReactiveCommand.CreateFromTask(TryServerAuth);
    }

    private Task TryServerAuth()
    {
        ErrorMessageURL = ValidateText(URL);
        ErrorMessageLogin = ValidateText(Login);
        ErrorMessagePassword = ValidateText(Password);
        if (ErrorMessageURL != string.Empty || ErrorMessageLogin != string.Empty || ErrorMessagePassword != string.Empty)
        {
            return Task.FromResult(false);
        }
        // TODO: пытаемся обратиться к BLL -> DAL с попыткой залогиниться на сервак
        // на время ожидания блочим экран и вешаем прогресс бар
        // если ответ успешен, то пишем, что все ок перекидываемся на новый экран
        // если ответ не успешен, то пишем, что все плохо. 
        // TODO: валидаторы, конвертеры - прикрутить к ServerAuth
        return _navigationService.NavigateAsync("/local_auth");
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
