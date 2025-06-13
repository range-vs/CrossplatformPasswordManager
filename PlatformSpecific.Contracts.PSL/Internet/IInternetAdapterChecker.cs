using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformSpecific.Contracts.PSL.Internet
{
    public interface IInternetAdapterChecker
    {
        bool IsInternetAdapterAvailable();
    }
}
