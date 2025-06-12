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

namespace CrossplatformPasswordManagerPL.Android.Sequrity
{
    public class OSAuth: IOSAuthPlatformSpecific
    {
        public OSAuth() { }

        public async Task<bool> RequestAuth()
        {
            // TODO: добавить альтер запрос(код, граф. ключ, камера?) если нет биометрии
            CrossFingerprint.SetCurrentActivityResolver(() => MainActivity.activity);
            var request = new AuthenticationRequestConfiguration(StringKeys.AccessConfirmationText, StringKeys.AccessConfirmationDescriptionText);
            var result = await CrossFingerprint.Current.AuthenticateAsync(request);
            return result.Authenticated;
        }
    }
}
