using AvaloniaInside.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossplatformPasswordManagerPL.ViewModels.Auth
{
    public class LocalAuthViewModel : ViewModelBase
    {
        private readonly INavigator _navigationService;

        public LocalAuthViewModel(INavigator navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
