using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformSpecific.Contracts.PSL
{
    public interface IFilesProviderPlatformSpecific
    {
        string GetLocalStoragePath();
        bool WriteFile(string path, string data);
        bool WriteFile(string path, byte[] data);

    }
}
