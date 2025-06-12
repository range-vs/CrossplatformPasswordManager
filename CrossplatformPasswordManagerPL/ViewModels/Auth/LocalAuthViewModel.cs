using AvaloniaInside.Shell;
using CrossplatformPasswordManagerPL.Assets;
using CrossplatformPasswordManagerPL.Helpers;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CrossplatformPasswordManagerPL.ViewModels.Auth
{
    public class LocalAuthViewModel : ViewModelBase
    {
        private readonly INavigator _navigationService;
        private string _pin;
        private bool _isErrorMessagePin;
        private string _repeatPin;
        private bool _isErrorMessageRepeatPin;
        private bool _isErrorMessageNotEqualPin;
        private bool _isFirstStart;
        private string _errorPin;

        public ICommand AuthCommand { get; set; }
        public ICommand RegisterPinCommand { get; set; }

        public bool IsErrorMessagePin
        {
            get => _isErrorMessagePin;
            set
            {
                this.RaiseAndSetIfChanged(ref _isErrorMessagePin, value);
            }
        }
        public bool IsErrorMessageRepeatPin
        {
            get => _isErrorMessageRepeatPin;
            set
            {
                this.RaiseAndSetIfChanged(ref _isErrorMessageRepeatPin, value);
            }
        }
        public bool IsErrorMessageCheckerPin
        {
            get => _isErrorMessageNotEqualPin;
            set
            {
                this.RaiseAndSetIfChanged(ref _isErrorMessageNotEqualPin, value);
            }
        }
        public string PIN
        {
            get => _pin;
            set
            {
                this.RaiseAndSetIfChanged(ref _pin, value);
                IsErrorMessagePin = Validator.ValidateText(_pin);
            }
        }
        public string RepeatPIN
        {
            get => _repeatPin;
            set
            {
                this.RaiseAndSetIfChanged(ref _repeatPin, value);
                IsErrorMessageRepeatPin = Validator.ValidateText(_repeatPin);
            }
        }
        public bool IsFirstStart
        {
            get => _isFirstStart;
            set
            {
                this.RaiseAndSetIfChanged(ref _isFirstStart, value);
            }
        }
        public string ErrorPIN
        {
            get => _errorPin;
            set
            {
                this.RaiseAndSetIfChanged(ref _errorPin, value);
                IsErrorMessageRepeatPin = Validator.ValidateText(_errorPin);
            }
        }

        public LocalAuthViewModel(INavigator navigationService)
        {
            // TODO: если первый вход в аппку - то показываем страницу с регистрацией пин
            // иначе страницу со входом по пин
            _navigationService = navigationService;
            IsFirstStart = true;
            AuthCommand = ReactiveCommand.Create(Auth);
            RegisterPinCommand = ReactiveCommand.CreateFromTask(RegisterPin);
        }

        private void Auth()
        {
            ErrorPIN = Resources.LocalAuthValidationPINErrorMessageText;
            IsErrorMessagePin = Validator.ValidateText(PIN);
            // TODO достаем пароль из сервиса и проверяем 
            if (IsErrorMessagePin || IsErrorMessageCheckerPin)
            {
                return;
            }
            // TODO: пройти на следующий экран авторизации
        }

        private async Task RegisterPin()
        {
            ErrorPIN = Resources.LocalAuthValidationPINsErrorMessageText;
            IsErrorMessagePin = Validator.ValidateText(PIN);
            IsErrorMessageRepeatPin = Validator.ValidateText(RepeatPIN);
            IsErrorMessageCheckerPin = PIN != RepeatPIN;
            if (IsErrorMessagePin || IsErrorMessageRepeatPin || IsErrorMessageCheckerPin)
            {
                return;
            }
            // TODO: региструем пин(пишем в файл  шифрованием) и проходим на след экран
            await PageLocator.StepToOSAuthPage(_navigationService);
        }
    }
}