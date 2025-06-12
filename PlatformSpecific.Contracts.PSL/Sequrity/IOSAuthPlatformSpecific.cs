using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PlatformSpecific.Contracts.PSL.Sequrity
{
    public interface IOSAuthPlatformSpecific
    {
        Task<bool> RequestAuth();
    }
}
