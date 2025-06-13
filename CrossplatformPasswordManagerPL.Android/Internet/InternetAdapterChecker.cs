using Android.Content;
using Android.Net;
using Database.Contracts.DAL;
using PlatformSpecific.Contracts.PSL.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossplatformPasswordManagerPL.Android.Internet
{
    public class InternetAdapterChecker : IInternetAdapterChecker
    {
        private Context? _context;

        public InternetAdapterChecker(Context? context)
        {
            _context = context;
        }

        private bool IsConnected()
        {
            ConnectivityManager connectivityManager = (ConnectivityManager)_context?.GetSystemService(Context.ConnectivityService);
            NetworkInfo activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
            return activeNetworkInfo != null && activeNetworkInfo.IsConnected;
        }

        private bool IsWifiConnected()
        {
            ConnectivityManager connectivityManager = (ConnectivityManager)_context?.GetSystemService(Context.ConnectivityService);
            NetworkInfo activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
            return activeNetworkInfo != null &&
                   activeNetworkInfo.IsConnected &&
                   activeNetworkInfo.Type == ConnectivityType.Wifi;
        }

        private bool IsMobileDataConnected()
        {
            ConnectivityManager connectivityManager = (ConnectivityManager)_context?.GetSystemService(Context.ConnectivityService);
            NetworkInfo activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
            return activeNetworkInfo != null &&
                   activeNetworkInfo.IsConnected &&
                   activeNetworkInfo.Type == ConnectivityType.Mobile;
        }

        public bool IsInternetAdapterAvailable()
        {
            return IsConnected();
        }
    }
}
