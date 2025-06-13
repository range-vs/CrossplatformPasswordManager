using PlatformSpecific.Contracts.PSL.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossplatformPasswordManagerPL.iOS.Internet
{
    public class InternetAdapterChecker : IInternetAdapterChecker
    {
        public bool IsInternetAdapterAvailable()
        {
            throw new NotImplementedException();
        }
    }
}
