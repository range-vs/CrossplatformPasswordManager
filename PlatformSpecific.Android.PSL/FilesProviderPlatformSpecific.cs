using PlatformSpecific.Contracts.PSL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformSpecific.Android.PSL
{
    public class FilesProviderPlatformSpecific: IFilesProviderPlatformSpecific
    {
        public FilesProviderPlatformSpecific()
        {
            Debug.WriteLine("Android!");
        }

        public string GetLocalStoragePath()
        {
            return "";
        }

        public bool WriteFile(string path, string data)
        {
            return true;
        }
        
        public bool WriteFile(string path, byte[] data)
        {
            return true;
        }

    }
}
