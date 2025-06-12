using Android.Hardware.Biometrics;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using Avalonia;
using PlatformSpecific.Contracts.PSL.Sequrity;
using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers.Common;
using Ninject.Common;
using CrossplatformPasswordManagerPL.Android.DI;
using Autofac;

namespace CrossplatformPasswordManagerPL.Android.Sequrity
{
    public class OSAuth: IOSAuthPlatformSpecific
    {
        public OSAuth() { }

        public async Task<bool> RequestAuth()
        {
            using (var scope = ServiceModule.Container?.BeginLifetimeScope())
            {
                var mainActivityProvider = scope?.Resolve<IMainActivityProvider>();
                if (mainActivityProvider != null)
                {
                    // TODO: добавить альтер запрос(код, граф. ключ, камера?) если нет биометрии
                    CrossFingerprint.SetCurrentActivityResolver(() => mainActivityProvider.GetMainActivity());
                    var request = new AuthenticationRequestConfiguration(StringKeys.AccessConfirmationText, StringKeys.AccessConfirmationDescriptionText);
                    var result = await CrossFingerprint.Current.AuthenticateAsync(request);
                    return result.Authenticated;
                }
            }
            return false;
        }
    }
}
