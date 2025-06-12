using PlatformSpecific.Contracts.PSL.Sequrity;
using System.Threading.Tasks;

namespace CrossplatformPasswordManagerPL.Browser.Sequrity
{
    public class OSAuth : IOSAuthPlatformSpecific
    {
        public OSAuth() { }
        public Task<bool> RequestAuth()
        {
            throw new System.NotImplementedException();
        }
    }
}
