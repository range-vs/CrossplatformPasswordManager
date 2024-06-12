using AvaloniaInside.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Helpers.Common;
using System.Diagnostics;

namespace CrossplatformPasswordManagerPL.Helpers
{
    public static class PageLocator
    {
        public static async Task StepToLocalAuthPage(INavigator navigationService)
        {
            await navigationService.NavigateAsync(StringKeys.LocalAuthPage);
        }
    }
}
