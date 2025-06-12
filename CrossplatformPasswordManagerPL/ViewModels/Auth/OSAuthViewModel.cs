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
    public class OSAuthViewModel : ViewModelBase
    {
        private readonly INavigator _navigationService;

        public OSAuthViewModel(INavigator navigationService)
        {
            // TODO: если первый вход в аппку - то предлагаем авторизацию системы, если она включена
            // иначе идем к главной странице менеджера пассов
            _navigationService = navigationService;
            Auth();
        }


        private void Auth()
        {
            
        }
    }
}