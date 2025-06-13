using PlatformSpecific.Contracts.PSL.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CrossplatformPasswordManagerPL.Desktop.Internet
{
    public class InternetAdapterChecker : IInternetAdapterChecker
    {
        public bool IsInternetAdapterAvailable()
        {
            return NetworkInterface.GetAllNetworkInterfaces()
            .Any(ni =>
                ni.OperationalStatus == OperationalStatus.Up &&
                ni.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                ni.GetIPProperties().GatewayAddresses.Any() && // Есть шлюз
                ni.GetIPProperties().UnicastAddresses
                    .Any(ip => ip.Address.AddressFamily == AddressFamily.InterNetwork) // IPv4
            );
        }
    }
}
