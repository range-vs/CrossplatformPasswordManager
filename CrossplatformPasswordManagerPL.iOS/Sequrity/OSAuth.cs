using PlatformSpecific.Contracts.PSL.Sequrity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossplatformPasswordManagerPL.iOS.Sequrity
{
    public class OSAuth : IOSAuthPlatformSpecific
    {
        public OSAuth() { }
        public Task<bool> RequestAuth()
        {
            throw new NotImplementedException();
        }
    }
}
