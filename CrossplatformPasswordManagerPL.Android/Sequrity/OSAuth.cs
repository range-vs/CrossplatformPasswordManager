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

namespace CrossplatformPasswordManagerPL.Android.Sequrity
{
    public class OSAuth: IOSAuthPlatformSpecific
    {
        public OSAuth() { }

        public async Task<bool> RequestAuth()
        {
            // TODO: добавить альтер запрос(код, ключ) если нет биометрии
            CrossFingerprint.SetCurrentActivityResolver(() => MainActivity.activity);
            var request = new AuthenticationRequestConfiguration("Prove you have fingers!", "Because without it you can't have access");
            var result = await CrossFingerprint.Current.AuthenticateAsync(request);
            return result.Authenticated;
        }
    }
}
